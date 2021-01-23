    namespace SandboxConsole
    {
        class Program
        {
            class Foo
            {
                public double Value { get; set; }
            }
            struct Foo2
            {
                public double Value { get; set; }
            }
    
            private static IReadOnlyList<double> GetValues()
            {
                return new[] { 10.0, 12.0, 15.5, 17.3 };
            }
    
            static void Main()
            {
                // example initializations
                var list = new Foo[4];
                var list2 = new Foo2[4];
    
                // somewhere else in the code
                var values = GetValues();
                // returns { 10.0, 12.0, 15.5, 17.3 }
    
                list.Update(values, (item, value) => item.Value = value);
                list2.Update(values, (ref Foo2 item, double value) => item.Value = value);
            }
        }
    }
