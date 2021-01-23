    internal class SomeData {
        public DateTime ValidDate { get; set; }
        // other data ...
    }
    class Program {
        static void Main(string[] args) {
            var stopWatch = new Stopwatch();
            // Test with closure
            IEnumerable<SomeData> data1 = CreateTestData(100000);
            stopWatch.Start();
            int yr = DateTime.Now.Year;
            List<SomeData> results1 = data1.Where(x => x.ValidDate.Year == yr).ToList();
            stopWatch.Stop();
            Console.WriteLine("With a closure - {0} ms", stopWatch.Elapsed.Milliseconds);
            // # Output on my machine (consistently): With a closure - 16 ms
            // Test without a closure
            stopWatch.Reset();
            stopWatch.Start();
            IEnumerable<SomeData> data2 = CreateTestData(100000);
            List<SomeData> results2 = data2.Where(x => x.ValidDate.Year == DateTime.Today.Year).ToList();
            stopWatch.Stop();
            Console.WriteLine("Without a closure - {0} ms", stopWatch.Elapsed.Milliseconds);
            // # Output on my machine: Without a closure - 33 ms
            Console.ReadLine();
        }
        private static IEnumerable<SomeData> CreateTestData(int numberOfItems) {
            var dt = DateTime.Today;
            for (int i = 0; i < numberOfItems; i++) {
                yield return new SomeData {ValidDate = dt};
            }
        }
    }
