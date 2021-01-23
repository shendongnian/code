    public static class DebugEx
    {
        [Conditional("DEBUG")]
        public static void Assert(Expression<Func<bool>> assertion, string message)
        {
            Debug.Assert(assertion.Compile()(), message, assertion.Body.ToString());
        }
    }
