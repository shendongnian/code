    public class Program
    {
        public class Test
        {
            Thread t;
            public Test()
            {
                t = new Thread(ThreadFunction);
                t.Name = "TestThread";
            }
            public void Start()
            {
                t.Start();
            }
            private void ThreadFunction()
            {
                Thread.Sleep(5000);
                Console.WriteLine("Function Complete");
            }
        }
        
        public static void Main()
        {
            Test test = new Test();
            test.Start();
            // sleep longer than my worker so it finishes
            Thread.Sleep(10000);
            // a place to place a breakpoint
            bool breakPointHere = true;
        }
    }
