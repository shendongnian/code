    using System;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static string data1;
            private static int[] idx = new int[12] { 0, 1, 3, 9, 31, 39, 47, 55, 61, 62, 63, 81 };
    
            private static void Main(string[] args)
            {
                string dataInput = "5JB01141570J4450901            1000    1051    2000    01161501B10G610M0350M200  0000006";
    
                Console.WriteLine("RESULT :");
    
                for (int i = 0; i < idx.Length - 1; i++)
                {
                    int len = idx[i + 1] - idx[i];
    
                    //format date
                    if (i == 2 | i == 7)
                    {
                        DateTime dt = Convert.ToDateTime(dataInput.Substring(idx[i], len).Substring(0, 2) +
                            "/" + dataInput.Substring(idx[i], len).Substring(2, 2) +
                            "/" + dataInput.Substring(idx[i], len).Substring(4, 2));
                        data1 = data1 + dt.ToShortDateString() + ",";
                    }
                    else {
                        data1 = data1 + dataInput.Substring(idx[i], len) + ",";
                    }
                }
    
                Console.WriteLine(data1 + DateTime.Now);
    
                Console.ReadKey();
            }
        }
    }
