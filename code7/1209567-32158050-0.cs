    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myInts = new HashSet<int>();
                for (var i = 0; i < 100000; i++)
                    myInts.Add(i);
    
                myInts.Remove(62345);
            }
        }
    }
