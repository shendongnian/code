    using System;
    using System.Text;
    using System.Threading;
    using System.Reflection;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string initializer = "foo";
                Contact obj = new Contact();
                var props = obj.GetType().GetProperties();
    
                foreach (var p in props)
                    p.SetValue(obj, initializer);
    
                Console.WriteLine("{0} {1}", obj.Address, obj.Children);
                Thread.Sleep(1000);
            }
        }
    
        class Contact
        {
            public string Address { get; set; }
            public string Children { get; set; }
        }
    }
