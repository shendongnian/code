    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<SomeObject> q = new List<SomeObject>();
                q.Select(c => new 
                {
                    Invoices = c.SomeList.Sum(),
                    Payments = c.OtherList.Sum(),
                   
                }).Select(x => x.Payments - x.Invoices);
     
            }
        }
        public class SomeObject
        {
            public int[] SomeList { get; set; }
            public int[] OtherList { get; set; }
        }
    }​
