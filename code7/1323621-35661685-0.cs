      public class Foo
        {
            private int pressedMain = 1;
            public int PressedMain
            {
                get
                {
                    return pressedMain;
                }
    
                set
                {
                    pressedMain = value;
                }
            }
        }
        class Program
        {
    
            static void Main(string[] args)
            {
    
                Foo foo = new Foo();
                foo.PressedMain++;
    
                Console.WriteLine(foo.PressedMain);
    
                Debugger.Break();
            }
        }
