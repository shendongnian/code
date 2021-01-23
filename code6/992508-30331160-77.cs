        // deliberately not [serializable]
        [ClassInterface(ClassInterfaceType.None)]
        [ComDefaultInterface(typeof(_Thread))]
        [System.Runtime.InteropServices.ComVisible(true)]
        public sealed class Thread : CriticalFinalizerObject, _Thread
        {
    
         //...
    
         [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal ExecutionContext.Reader GetExecutionContextReader()
            {
                return new ExecutionContext.Reader(m_ExecutionContext);
            }
        }
