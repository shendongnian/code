    value.Value<double>() - 572ms
    value.ToObject<double>() - 6319ms
.
        private static void RunPerfTest()
        {
            int loops = 100000000;
            JValue value = new JValue(1000d);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < loops; i++)
            {
                double x = value.Value<double>();
            }
            sw.Stop();
            Console.WriteLine("value.Value<double>()" + sw.ElapsedMilliseconds);
            sw.Restart();
            for (int i = 0; i < loops; i++)
            {
                double x = value.ToObject<double>();
            }
            sw.Stop();
            Console.WriteLine("value.ToObject<double>()" + sw.ElapsedMilliseconds);
        }
