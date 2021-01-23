    [Serializable]
    public class LogPerformance : OnMethodBoundaryAspect
    {
        [NonSerialized]
        Stopwatch _stopWatch;
        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopWatch = Stopwatch.StartNew();
            base.OnEntry(args);
        }
        public override void OnExit(PostSharp.Aspects.MethodExecutionArgs args)
        {
            Console.WriteLine(string.Format("[{0}] took {1} ms to execute",
              new StackTrace().GetFrame(1).GetMethod().Name,
                _StopWatch.ElapsedMilliseconds));
            base.OnExit(args);
        }
    }
