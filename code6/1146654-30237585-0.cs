    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication28
    {
        class Program
        {
            public enum LunchBreak : int
            {
                Paid_20 = 0,
                Unpaid_20 = 1,
            }
            static void Main(string[] args)
            {
                foreach (LunchBreak type in Enum.GetValues(typeof(LunchBreak)))
                {
                    LunchBreak LunchItem = type;
     
                }
     
            }
        }
    }
