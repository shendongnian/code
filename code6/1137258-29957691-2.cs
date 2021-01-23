    private static void RunLoopTester()
            {
                Console.WriteLine("Building dictionary...");
                var parameters = new Dictionary<string, string>();
                for(var i = 0;i< 10000;i++)
                {
                    parameters.Add(string.Format("param{0}",i),string.Format("value{0}", i));
                }
                var stopWatch = new Stopwatch();
                Console.WriteLine("Using foreach statement...");
                stopWatch.Start();
                var param = string.Empty;
                var value = string.Empty;
                foreach(var k in parameters.Keys)
                {
                    param += string.Format("{0}{1}", string.IsNullOrEmpty(param) ? string.Empty : ",", k);
                    value += string.Format("{0}{1}", string.IsNullOrEmpty(value) ? string.Empty : ",", parameters[k]);
    
                }
                stopWatch.Stop();
                Console.WriteLine("Elapsed Time: {0}", stopWatch.ElapsedMilliseconds);
                Console.WriteLine("Using simple syntax...");
                param = string.Empty;
                value = string.Empty;
                stopWatch.Reset();
                stopWatch.Start();
                param = string.Join(",", parameters.Keys);
                value = string.Join(",", parameters.Values);
                stopWatch.Stop();
                Console.WriteLine("Elapsed Time: {0}", stopWatch.ElapsedMilliseconds);
                Console.ReadLine();
            }
