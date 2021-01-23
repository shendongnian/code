    class Program
        {
            class Super
            {
                public static List<Super> methodA() { Console.WriteLine("SUPER"); return new List<Super>(); }
            }
            class Sub : Super
            {
                public static List<Sub> methodA() { Console.WriteLine("SUB"); return new List<Sub>(); }
    
                public void callSuper()
                {
                    Super.methodA();
                }
    
                public void callSub()
                {
                    Sub.methodA();
                }
            }
    
            static void Main(string[] args)
            {
                Super.methodA();
    
                Sub.methodA();
    
                var s = new Sub();
                s.callSuper();
                s.callSub();
    
                Console.ReadLine();
            }
        }
