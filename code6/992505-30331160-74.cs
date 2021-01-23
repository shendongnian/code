        public class SocketAsyncEventArgs : EventArgs, IDisposable {
        //...
        // Method called to prepare for a native async socket call.
        // This method performs the tasks common to all socket operations.
        internal void StartOperationCommon(Socket socket) {
     
            //...
     
            // Prepare execution context for callback.
     
            if (ExecutionContext.IsFlowSuppressed()) {    
            // This condition is what you need to pass.
     
                // Fast path for when flow is suppressed.
     
                m_Context = null;
                m_ContextCopy = null;
     
            } else {
     
                // Flow is not suppressed.
     
                //...
     
                // If there is an execution context we need
                 //a fresh copy for each completion.
                
                if(m_Context != null) {
                    m_ContextCopy = m_Context.CreateCopy();
                }
            }
     
            // Remember current socket.
            m_CurrentSocket = socket;
           }
   
 
            [Pure]
            public static bool IsFlowSuppressed()
            {
                return  Thread.CurrentThread.GetExecutionContextReader().IsFlowSuppressed;
            }
           //...
            }
