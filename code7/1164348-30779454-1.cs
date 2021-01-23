    namespace Base.Manager {
        [Obsolete("This method is deprecated, please use Trace.Logger.Send")]
        public static class Logger {
            public static void Send(string message) {
                // Delegate work to someone else...
                Trace.Logger.Send(message);
            }
        }
