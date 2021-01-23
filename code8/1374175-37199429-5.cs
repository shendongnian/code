    public interface IFeedbackAction
    {
        void ProvideFeedback(string text);
    }
    public interface IFeedbackMetadata
    {
        string Name { get; }
    }
    [Export(typeof(IFeedbackAction)), ExportMetadata("Name", "Console")]
    public interface ConsoleFeedbackAction : IFeedbackAction { ... }
    [Export(typeof(IFeedbackAction)), ExportMetadata("Name", "Trace")]
    public interface TraceFeedbackAction : IFeedbackAction { ... }
    public static class Feedback
    {
        [ImportMany]
        public IEnumerable<Lazy<IFeedbackAction, IFeedbackMetadata>> FeedbackActions { get; set; }
        
        private IFeedbackAction feedbackAction;
        public static void ProvideFeedback(string text)
        {
            if (feedbackAction == null)
            {
                // synchronize to avoid duplicate calls
                lock (syncLock)
                {
                    if (feedbackAction == null)
                    {
                        var value = ConfigurationManager.AppSettings["FeedbackAction"];
                        feedbackAction = GetFeedbackAction(value);
                    }
                }
            }
            feedbackAction.ProvideFeedback(text);
        }
        private static IFeedbackAction GetFeedbackAction(string name)
        {
            return FeedbackActions
                .First(l => l.Metadata.Name.Equals(name)).Value;
        }
    }
