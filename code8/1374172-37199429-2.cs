    public static class Feedback
    {
        public static Action<string> feedbackAction;
        public static object syncLock = new object();
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
                        feedbackAction = FeedbackActions.GetAction(value);
                    }
                }
            }
            feedbackAction(text);
        }
    }
