    [Serializable]
    public sealed class TraceAttribute : OnMethodBoundaryAspect
    {        
        private readonly string _argumentsFormat;        
        [NonSerialized]
        private string _methodName;        
        public TraceAttribute() {
            
        }
        public TraceAttribute(string argumentsFormat) {
            _argumentsFormat = argumentsFormat;
        }
        public override void RuntimeInitialize(MethodBase method) {
            _methodName = method.Name;
        }
        public override void OnEntry(MethodExecutionArgs args) {
            string msg = $"[{_methodName}]: entered";
            if (!String.IsNullOrWhiteSpace(_argumentsFormat)) {
                msg += String.Format(". Arguments:" + _argumentsFormat, args.Arguments.ToArray());
            }
            Console.WriteLine(msg);
        }
        // Invoked at runtime after the target method is invoked (in a finally block).
        public override void OnExit(MethodExecutionArgs args) {
            string msg = $"[{_methodName}]: exited";
            if (!String.IsNullOrWhiteSpace(_argumentsFormat)) {
                msg += String.Format(". Arguments: " + _argumentsFormat, args.Arguments.ToArray());                
            }
            Console.WriteLine(msg);
        }
        public override void OnException(MethodExecutionArgs args) {
            string msg = $"[{_methodName}]: exception";
            if (!String.IsNullOrWhiteSpace(_argumentsFormat))
            {
                msg += String.Format(". Arguments: " + _argumentsFormat, args.Arguments.ToArray());                
            }
            msg += ". Details: " + args.Exception.ToString();
            Console.WriteLine(msg);
        }
    }
