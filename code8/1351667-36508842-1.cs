    using System;
    namespace ConsoleApplication1
    {
        class Contract
        {
            public DateTime StartDate { get; set; }
            public int CurrentQuarter
            {
                get
                {
                    var adjustedNow = new DateTime(StartDate.Year, 1, 1) + (DateTime.Now - StartDate);
                    var quarter = (adjustedNow.Month + (adjustedNow.Year - StartDate.Year) * 12 + 2) / 3;
                    return quarter;
                }
            }
            // ...
        }
        class Program
        {
            static void Main()
            {
                var contract = new Contract { StartDate = new DateTime(2015, 1, 10) };
                Console.WriteLine("Current contract quarter is {0}", contract.CurrentQuarter);
            }
        }
    }
