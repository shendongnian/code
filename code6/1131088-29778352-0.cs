    public static class DebugEx
    {
        private static readonly Dictionary<Regex, string> _replacements;
        static DebugEx()
        {
            _replacements = new Dictionary<Regex,string>()
            {
                {new Regex("value\\([^)]*\\)\\."), string.Empty},
                {new Regex("\\(\\)\\."), string.Empty},
                {new Regex("\\(\\)\\ =>"), string.Empty},
                {new Regex("Not"), "!"}
            };
        }
        [Conditional("DEBUG")]
        public static void Assert(Expression<Func<bool>> assertion, string message)
        {
            if (!assertion.Compile()())
                Debug.Assert(false, message, FormatFailure(assertion));
        }
        private static string FormatFailure(Expression assertion)
        {
            return string.Format("Assertion '{0}' failed.", Normalize(assertion.ToString()));
        }
 
        private static string Normalize(string expression)
        {
            string result = expression;
            foreach (var pattern in _replacements)
            {
                result = pattern.Key.Replace(result, pattern.Value);
            }
            return result.Trim();
        }
    }
