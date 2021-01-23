        static void Main(string[] args)
        {
            int size = 10000;
            Dictionary<string, List<long>> time = new Dictionary<string, List<long>>()
            {
                {"InBetween OneProperty", new List<long>() },
                {"Moumit OneProperty", new List<long>() },
                {"Mine OneProperty", new List<long>() },
                {"InBetween LotProperties", new List<long>() },
                {"Moumit LotProperties", new List<long>() },
                {"Mine LotProperties", new List<long>() },
            };
            List<OneProperty> oneProperties = new List<OneProperty>();
            List<LotProperties> lotProperties = new List<LotProperties>();
            for (int i = 0; i < size; ++i)
            {
                oneProperties.Add(new OneProperty() { Key = i.ToString() });
                lotProperties.Add(new LotProperties() { Key = i.ToString() });
            }
            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < 1000; ++i)
            {
                sw.Start();
                InBetween.LikeSearch(oneProperties, "Key", "999");
                sw.Stop();
                time["InBetween OneProperty"].Add(sw.Elapsed.Ticks);
                sw.Reset();
                sw.Start();
                Moumit.Filter(oneProperties, "Key", "999");
                sw.Stop();
                time["Moumit OneProperty"].Add(sw.Elapsed.Ticks);
                sw.Reset();
                sw.Start();
                Mine.LikeSearch(oneProperties, x => x.Key, "999");
                sw.Stop();
                time["Mine OneProperty"].Add(sw.Elapsed.Ticks);
                sw.Reset();
                sw.Start();
                InBetween.LikeSearch(lotProperties, "Key", "999");
                sw.Stop();
                time["InBetween LotProperties"].Add(sw.Elapsed.Ticks);
                sw.Reset();
                sw.Start();
                Moumit.Filter(lotProperties, "Key", "999");
                sw.Stop();
                time["Moumit LotProperties"].Add(sw.Elapsed.Ticks);
                sw.Reset();
                sw.Start();
                Mine.LikeSearch(lotProperties, x => x.Key, "999");
                sw.Stop();
                time["Mine LotProperties"].Add(sw.Elapsed.Ticks);
                sw.Reset();
            }
            foreach (string key in time.Keys)
                Console.WriteLine($"{key}: {new TimeSpan((long)time[key].Average())}");
            Console.ReadKey();
        }
        class OneProperty
        {
            public string Key { get; set; }
        }
        class LotProperties
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
            public string D { get; set; }
            public string E { get; set; }
            public string F { get; set; }
            public string G { get; set; }
            public string H { get; set; }
            public string I { get; set; }
            public string J { get; set; }
            public string K { get; set; }
            public string L { get; set; }
            public string M { get; set; }
            public string N { get; set; }
            public string O { get; set; }
            public string P { get; set; }
            public string Q { get; set; }
            public string R { get; set; }
            public string S { get; set; }
            public string T { get; set; }
            public string U { get; set; }
            public string V { get; set; }
            public string W { get; set; }
            public string X { get; set; }
            public string Y { get; set; }
            public string Z { get; set; }
            public string Key { get; set; }
        }
