        [TestMethod]
        public void MeasureParallelForEach()
        {
            string[] classOptions = { "AS", "CS", "LS", "PE", "WP", "LS" };
            global.BuildItems();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            Console.WriteLine("This test is a plinq over an array");
            sw.Start();
            IDictionary<string, Group> groups = global.classOptions.Distinct().ToDictionary(x => x, x => new Group(x));
            Parallel.ForEach(global.items, d => groups[d.cl].Add(d.uc));
            foreach (var item in groups)
                Console.WriteLine(string.Format("{0} : {1} ", item.Key, item.Value.Average));
            Console.WriteLine("Parallel.ForEach elapsed : " + sw.Elapsed);
        }
        public class Group
        {
            private int count;
            private decimal sum;
            public Group(string key)
            {
                Key = key;
            }
            public void Add(decimal d)
            {
                sum += d;
                count++;
            }
            public string Key { get; private set; }
            public decimal Average { get { return count==0?0m:sum/count; }}
        }
