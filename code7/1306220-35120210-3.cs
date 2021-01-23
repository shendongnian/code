        static void Main(string[] args)
        {
            GCTest();
            
            Console.ReadKey();
        }
        private static void GCTest()
        {
            Class1 c1 = new Class1(1);
            {
                Class1 c2 = new Class1(2);
                {
                    Class1 c3 = new Class1(3);
                }
                //this is not collecting object c3 which is out of scope here
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            //this is not collecting object c2 which is out of scope here
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
