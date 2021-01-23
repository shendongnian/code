    [Serializable] 
      public sealed class ExecutionContext : IDisposable, ISerializable
       {
        //..irrelevent code here.
        // Misc state variables.
        private ExecutionContext m_Context;
        private ExecutionContext m_ContextCopy;
        private ContextCallback m_ExecutionCallback;
        //..
        }
