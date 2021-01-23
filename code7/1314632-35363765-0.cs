            static void Main(string[] args)
            {
                List<int> testList = new List<int>();
                System.Threading.Thread.Sleep(300);
                Random rng = new Random(123);
                for (int y = 0; y < 50; y++)
                {
                    testList.Add(y);
                    Console.WriteLine(string.Format("Added item {0}!", y));
                };
    
                Thread testThread1 = new Thread(() => FillList(testList));
                testThread1.Start();
                Console.ReadKey();
            }
    
            public static void FillList(List<int> pTestList)
            {
                List<Number> testList = new List<Number>();
                Random rng = new Random(123);
                foreach (var item in pTestList)
                {
                    testList.Add(new Number() { IntNumber = item, Position = rng.Next() });
                }
    
                foreach (Number x in testList.OrderBy(x => x.Position))
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine(x.IntNumber);
                }
            }
    
            public struct Number
            {
                public int Position { get; set; }
                public int IntNumber { get; set; }
            }
