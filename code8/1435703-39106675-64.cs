    [Config(typeof(Config)), LegacyJitX86Job, LegacyJitX64Job, RyuJitX64Job, RPlotExporter]
    public class ArrayBenchmarks
    {
        private static readonly int[] lookup = new[] {1, 2, 4, 8, 16, 32, 666, /*...*/};
        [MethodImpl(MethodImplOptions.NoInlining)]
        public int ConvertStatic(int i)
        {
            return lookup[i];
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public int ConvertLocal(int i)
        {
            int[] localLookup = new[] {1, 2, 4, 8, 16, 32, 666, /*...*/};
            return localLookup[i];
        }
        [Benchmark]
        public int Static()
        {
            int sum = 0;
            for (int i = 0; i < 10001; i++)
                sum += ConvertStatic(0);
            return sum;
        }
        [Benchmark]
        public int Local()
        {
            int sum = 0;
            for (int i = 0; i < 10001; i++)
                sum += ConvertLocal(0);
            return sum;
        }
        private class Config : ManualConfig
        {
            public Config()
            {
                Add(new MemoryDiagnoser());                
                Add(MarkdownExporter.StackOverflow);
            }
        }
    }
