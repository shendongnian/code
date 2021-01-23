        public CallerContext Info([CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0)
        {
            return new CallerContext(_log, LogLevel.Info, memberName, lineNumber);
        }
        public struct CallerContext
        {
            private readonly Logger _logger;
            private readonly LogLevel _level;
            private readonly string _memberName;
            private readonly int _lineNumber;
            public CallerContext(Logger logger, LogLevel level, string memberName, int lineNumber)
            {
                _logger = logger;
                _level = level;
                _memberName = memberName;
                _lineNumber = lineNumber;
            }
            public void Log(string message, params object[] args)
            {
                _logger.Log(_level, BuildMessage(message, _memberName, _lineNumber), args);
            }
            private static string BuildMessage(string message, string memberName, int lineNumber)
            {
                return memberName + ":" + lineNumber + "|" + message;
            }
        }
