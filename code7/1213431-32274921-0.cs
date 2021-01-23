    using System;
    using System.Runtime.InteropServices;
    
    [module: DefaultCharSet(CharSet.Unicode)]
    
    class Program {
        static void Main(string[] args) {
            var sla = typeof(Foo).StructLayoutAttribute;
            Console.WriteLine(sla.CharSet);
            Console.ReadLine();
        }
    }
    
    struct Foo { };
