    internal struct Reader
        {
            ExecutionContext m_ec;
            //..not relevent code here.
            public bool IsFlowSuppressed 
            {
            #if !FEATURE_CORECLR
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
           #endif
                get { return IsNull ? false : m_ec.isFlowSuppressed; } 
            }
            //..irrelevent code here.
         }
