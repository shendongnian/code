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
                    var now = DateTime.Now.Date;
                    var month = (now.Year*12 + now.Month - 1) - (StartDate.Year*12 + StartDate.Month - 1);
                    if (now.Day < StartDate.Day) month--;
                    var quarter = (month / 3) + 1;
                    return quarter;
                }
            }
            // ...
        }
        class Program
        {
            static void Main()
            {
                var contract = new Contract { StartDate = new DateTime(2016, 1, 12) };
                Console.WriteLine("Current contract quarter is {0}", contract.CurrentQuarter);
            }
        }
    }
