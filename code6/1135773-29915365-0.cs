    static int tickCountLength = 1000;
        int[] tickCounts = new int[tickCountLength];
        int numberOfTicks = 0;
        TimeSpan dtn;
        void DoCaptureRenderTarget(Device device, string hook)
        {
            //Environment.TickCount-->array
            DateTime start1 = DateTime.Now;
            tickCounts[numberOfTicks] = Environment.TickCount;
            numberOfTicks++;
            
            DateTime end1 = DateTime.Now;
            this.DebugMessage("Capture Time Testing " + (end1 - start1).ToString());
            dtn = end1 - start1;
            if (dtn.TotalMilliseconds > 0)
            {
                string fffff = "fgf";
            }
            if (numberOfTicks >= tickCountLength)
            {
                StreamWriter w = new StreamWriter(@"c:\Milliseconds\TickCount.txt", true);
                foreach (int tick in tickCounts)
                {
                    w.WriteLine("TickCount === > " + tick.ToString());
                }
                w.Close();
                numberOfTicks = 0;
            }
