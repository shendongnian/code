    using System;
    using System.Linq;
    namespace ConsoleApplication8
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetPercent("1.68"));
            Console.ReadLine();
        }
        static string GetPercent(string val)
        {
            var vals = new[]
            {
                new {from = "1.00", to = "1.50", percent = "10.6%"},
                new {from = "1.51", to = "2.0", percent = "20.4%"},
                new {from = "2.01", to = "2.50", percent = "25.5%"}
            };
            return
                vals.Single(
                    v =>
                        Convert.ToDouble(val) >= Convert.ToDouble(v.from) &&
                        Convert.ToDouble(val) <= Convert.ToDouble(v.to)).percent;
        }
    }
    }
