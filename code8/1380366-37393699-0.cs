    public static class CPUStats
    {
        public static Event<CPUEventArgs> Measured;
        public static CPUStats()
        {
            Task.Factory.StartNew(() =>
            {
                while(true)
                {
                    ... // poll CPU data periodically
                    Measured?.Invoke(null, new CPUEventArgs() { LT = lt, L1 = l1, ... });
                }
            }, TaskCreationOptions.LongRunning);
        }
    }
    public static class StatsWriter
    {
        static int lt;
        static int l1;
        ...
        public static StatsWriter()
        {
            CPUStats.Measured += (s, e) =>
            {
               lt = e.LT;
               l1 = e.L1;
            }
        }
        public static void Save()
        {
            var text = $"{DateTime.Now} CPU[{lt},{l1}...]";
            ... // save text
        }
    }
