    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    namespace ConsoleApplicationStringBuilder
    {
        class Program
        {
            static void Main(string[] args)
            {
                /*
                john   teacher 1988 married
                marcel engineer1976 single
                emi    professo1975 married
                */
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("{0, -7}{1, -8}{2, -5}{3}", Truncate("john", 6), Truncate("teacher", 8), 1988, Truncate("married", 7)));
                sb.AppendLine(string.Format("{0, -7}{1, -8}{2, -5}{3}", Truncate("marcel", 6), Truncate("engineer", 8), 1976, Truncate("single", 7)));
                sb.AppendLine(string.Format("{0, -7}{1, -8}{2, -5}{3}", Truncate("emi", 6), Truncate("professor", 8), 1975, Truncate("married", 7)));
                string s = sb.ToString();
                Console.WriteLine(s);
                //Write to file
                using (TextWriter tw = File.CreateText("C:\\test.txt"))
                {
                    tw.Write(s);
                    tw.Flush();
                    tw.Close();
                }
                Console.WriteLine("File written to C:\\test.txt"); ;
                Console.ReadLine();
            }
            static public string Truncate(string value, int max)
            {
                return value.Substring(0, Math.Min(value.Length, max));
            }
        }
    }
