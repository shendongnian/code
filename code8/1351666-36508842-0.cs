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
                    var offset = StartDate - new DateTime(StartDate.Year, 1, 1);
                    var quarter = ((DateTime.Now - offset).Month + 2)/3;
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
