     [Pure]
        public static bool IsFlowSuppressed()
        {
            return Thread.CurrentThread.GetExecutionContextReader().IsFlowSuppressed;
        }
