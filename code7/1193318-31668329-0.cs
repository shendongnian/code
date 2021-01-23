    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                A a = new A();
                var results = a.Bs.Where(x => x.Date > DateTime.Now.AddDays(30));
            }
        }
        public class A
        {
            public List<B> Bs { get; set; }
        }
        public class B
        {
            public DateTime Date { get; set; }
        }
    }
    ​
