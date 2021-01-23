    [BenchmarkTask(platform: BenchmarkPlatform.X86)]
    public class Jit_RegistersVsStack
    {
        private const int IterationCount = 100001;
        [Benchmark]
        [OperationsPerInvoke(IterationCount)]
        public string WithoutStopwatch()
        {
            double a = 1, b = 1;
            for (int i = 0; i < IterationCount; i++)
            {
                // fld1  
                // faddp       st(1),st
                a = a + b;
            }
            return string.Format("{0}", a);
        }
        [Benchmark]
        [OperationsPerInvoke(IterationCount)]
        public string WithStopwatch()
        {
            double a = 1, b = 1;
            var sw = new Stopwatch();
            for (int i = 0; i < IterationCount; i++)
            {
                // fld1  
                // fadd        qword ptr [ebp-14h]
                // fstp        qword ptr [ebp-14h]
                a = a + b;
            }
            return string.Format("{0}{1}", a, sw.ElapsedMilliseconds);
        }
        [Benchmark]
        [OperationsPerInvoke(IterationCount)]
        public string WithTwoStopwatches()
        {
            var outerSw = new Stopwatch();
            double a = 1, b = 1;
            var sw = new Stopwatch();
            for (int i = 0; i < IterationCount; i++)
            {
                // fld1  
                // faddp       st(1),st
                a = a + b;
            }
            return string.Format("{0}{1}", a, sw.ElapsedMilliseconds);
        }
    }
