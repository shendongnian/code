    public enum FeedbackAction
    {
        Console,
        Trace,
        ...
    }
    public static class FeedbackActions
    {
        public static void Console(string text) { ... }
        public static void Trace(string text) { ... }
        public static Action<string> GetAction(FeedbackAction action)
        {
            switch (action)
            {
                case FeedbackAction.Console:
                    return Console;
                case FeedbackAction.Trace:
                    return Trace;
                default:
                    throw new ArgumentException("Invalid feedback action.", nameof(action));
            }
        }
    }
