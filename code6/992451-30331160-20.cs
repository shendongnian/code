     [System.Security.SecurityCritical]  // auto-generated_required
        public static AsyncFlowControl SuppressFlow()
        {
            if (IsFlowSuppressed())
            {
                throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotSupressFlowMultipleTimes"));
            }
            Contract.EndContractBlock();
            AsyncFlowControl afc = new AsyncFlowControl();
            afc.Setup();
            return afc;
        }
