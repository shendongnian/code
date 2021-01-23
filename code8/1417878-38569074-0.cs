    [Serializable]
    public class ProfilingAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry( MethodExecutionArgs args )
        {
            Stopwatch sw = Stopwatch.StartNew();
            args.MethodExecutionTag = sw;
        }
        public override void OnExit( MethodExecutionArgs args )
        {
            Stopwatch sw = (Stopwatch) args.MethodExecutionTag;
            sw.Stop();
            Console.WriteLine( "Method {0} executed for {1}ms.",
                               args.Method.Name, sw.ElapsedMilliseconds );
        }
    }
