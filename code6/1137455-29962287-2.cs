    using System;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                string allwords = "This is a test this is a test aaaaaaaaaaa this is a test ";
                string[] c = allwords.Split();
                bool moreThanten = false;
                foreach (string v in c)
                {
                    if (v.Length > 10)
                    {
                        moreThanten = true;
                    }
                }
                Console.WriteLine(moreThanten == false ? allwords : "Woahh there one of these words is more than 10 chars");
            }
        }
    }
