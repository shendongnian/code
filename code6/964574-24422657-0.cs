      class SortedListTest
        {
            public static void Test()
            {
                var list = new SortedList<double, string>(new MyComparer());
    
                list[0.00] = "A";
                list[1.00] = "B";
                list[2.00] = "C";
    
                Console.WriteLine(list[0.55]);
            }
            private static void Main()
            {
                SortedListTest.Test();
            }
        }
    
        internal class MyComparer : IComparer<double>
        {
            public int Compare(double x, double y)
            {
                return (int) (Math.Round(x) - Math.Round(y));
            }
    
        }
