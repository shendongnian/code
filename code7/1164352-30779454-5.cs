    namespace Base.Manager {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static class Logger {
            [Obsolete("This method is deprecated, please use Trace.Logger.Send")]
            public static void Send(string message) {
                // Delegate work to someone else...
                Trace.Logger.Send(message);
            }
        }
