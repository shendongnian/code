    [Serializable]
    public sealed class TraceAttribute : OnMethodBoundaryAspect
    {
        // This field is initialized and serialized at build time, then deserialized at runtime.
        private readonly string category;
        // These fields are initialized at runtime. They do not need to be serialized.
        [NonSerialized] private string enteringMessage;
        [NonSerialized] private string exitingMessage;
        // Default constructor, invoked at build time.
        public TraceAttribute()
        {
        }
        // Constructor specifying the tracing category, invoked at build time.
        public TraceAttribute(string category)
        {
            this.category = category;
        }
        // Invoked only once at runtime from the static constructor of type declaring the target method.
        public override void RuntimeInitialize(MethodBase method)
        {
            string methodName = method.DeclaringType.FullName + method.Name;
            this.enteringMessage = "Entering " + methodName;
            this.exitingMessage = "Exiting " + methodName;
        }
        // Invoked at runtime before that target method is invoked.
        public override void OnEntry(MethodExecutionArgs args)
        {
            Trace.WriteLine(this.enteringMessage, this.category);
        }
        // Invoked at runtime after the target method is invoked (in a finally block).
        public override void OnExit(MethodExecutionArgs args)
        {
            Trace.WriteLine(this.exitingMessage, this.category);
        }
    }
