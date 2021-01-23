    namespace ConsoleApplication1
    {
        delegate int F(int x, int y, int z);
        delegate int Fz(int x, int y);
        delegate Fz Cz(F formula, int z);
        class Program
        {
            static Fz Curry(F f, int z)
            {
                return (x, y) => { return f(x,y,z); };
            }
            static void Main(string[] args)
            {
                {   // Verbose version
                    F f = (x, y, z) => { return x + y + z; };
                    Fz z5 = Curry(f, 5);
                    int result = z5(1, 3);
                    System.Console.WriteLine("1 + 3 + 5 = {0}", result);
                }
                {   // Inline version 1
                    Fz z5 = Curry((x, y, z) => { return x + y + z; }, 5);
                    int result = z5(1, 3);
                    System.Console.WriteLine("1 + 3 + 5 = {0}", result);
                }
                {   // Inline version 2
                    int result = Curry((x, y, z) => { return x + y + z; }, 5)(1, 3);
                    System.Console.WriteLine("1 + 3 + 5 = {0}", result);
                }
                {   // Inline version 3
                    Cz zn = (f, z) => { return (x, y) => { return f(x, y, z); }; };
                    int result = zn((x, y, z) => { return x + y + z; }, 5)(1, 3);
                    System.Console.WriteLine("1 + 3 + 5 = {0}", result);
                }
                {   // Inline version 4 (max obfuscation)
                    int result = ((Cz)((f, z) => { return (x, y) => { return f(x, y, z); }; }))((x, y, z) => { return x + y + z; }, 5)(1, 3);
                    System.Console.WriteLine("1 + 3 + 5 = {0}", result);
                }
            }
        }
    }
