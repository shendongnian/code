    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                for (double i = 500d; i < 5e23; i *= 100d)
                {
                    Console.WriteLine(i.ToMyNumber());
                }
                Console.Read();
            }
        }
        public static class helper
        {
            private static readonly  List<string> myNum;
            static helper()
            {
                myNum = new List<string>();
                myNum.Add("");
                myNum.Add("kilo");
                myNum.Add("mill");
                myNum.Add("bill");
                myNum.Add("tril");
                myNum.Add("quad");
                myNum.Add("quin");
                myNum.Add("sext");
                // ....
            }
            public static string ToMyNumber(this double value)
            {
                string initValue = value.ToString();
                int num = 0;
                while (value >= 1000d)
                {
                    num++;
                    value /= 1000d;
                }
                return string.Format("{0} {1} ({2})", value, myNum[num], initValue);
            }
        }
    }
