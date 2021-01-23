    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace StackOverflow
    {
        public class Class1
        {
            public static void Main(string[] args)
            {
                var serv1 = new Testserv1();
                foreach (int x in serv1.CallA())
                {
                    foreach (int y in serv1.CallB())
                    {
                    }
                }
                Console.WriteLine(string.Format("Calls to A: {0}", serv1.ACount));
                Console.WriteLine(string.Format("Calls to B: {0}", serv1.BCount));
                Console.ReadLine();
            }
    
        }
    
        public class Testserv1
        {
            private static int CallACount = 0;
            private static int CallBCount = 0;
    
            public int ACount {
                get
                {
                    return CallACount;
                }
            }
    
            public int BCount
            {
                get
                {
                    return CallBCount;
                }
            }
    
            public Testserv1()
            {
                //InitializeComponent();
    
            }
    
            public List<int> CallA()
            {
                CallACount++;
                return new List<int>() {
                    1,2,3,4,5,6
                };
            }
    
            public List<int> CallB()
            {
                CallBCount++;
                return new List<int>() {
                    7,8,9,10,11,12
                };
            }
    
    
        }
    }
