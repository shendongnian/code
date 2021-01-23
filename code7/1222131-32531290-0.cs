    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.ReadKey();
        }
        [Measure]
        public static void Test() {
            Thread.Sleep(1000);
        }
    }
    [Serializable]
    public sealed class MeasureAttribute : OnMethodBoundaryAspect
    {        
        private string _methodName;
        [NonSerialized]
        private Stopwatch _watch;
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo) {
            base.CompileTimeInitialize(method, aspectInfo);
            // save method name at _compile_ time
            _methodName = method.Name;
        }
        
        public override void OnEntry(MethodExecutionArgs args) {
            base.OnEntry(args);
            // here you have access to everything about method
            _watch = Stopwatch.StartNew();
        }
        public override void OnExit(MethodExecutionArgs args) {
            base.OnExit(args);
            if (_watch != null) {
                _watch.Stop();
                Console.WriteLine("Method {0} took {1}ms", _methodName, _watch.ElapsedMilliseconds);
            }
        }
        public override void OnException(MethodExecutionArgs args) {
            base.OnException(args);
            // do what you want on exception
        }
    }
