        [Serializable] 
        public sealed class ExecutionContext : IDisposable, ISerializable
        {
        //...
        // Misc state variables.
        private ExecutionContext m_Context;
        private ExecutionContext m_ContextCopy;
        private ContextCallback m_ExecutionCallback;
        //...
    
        internal struct Reader
        {
            ExecutionContext m_ec;
            //...
             public bool IsFlowSuppressed 
            {
             #if !FEATURE_CORECLR
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
             #endif
                get { return IsNull ? false : m_ec.isFlowSuppressed; } 
            }
            
          } //end of Reader
         
    
        internal bool isFlowSuppressed 
           { 
            get 
            { 
                return (_flags & Flags.IsFlowSuppressed) != Flags.None; 
            }
            set
            {
                Contract.Assert(!IsPreAllocatedDefault);
                if (value)
                    _flags |= Flags.IsFlowSuppressed;
                else
                    _flags &= ~Flags.IsFlowSuppressed;
            }
           }
    
    
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
        //...
        }//end of ExecutionContext.
