    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Struct, Inherited = false)]
    public sealed class DebuggerStepThroughAttribute : Attribute
    {
        public DebuggerStepThroughAttribute();
    }
