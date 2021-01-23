    using System;
    using static System.Console;
    ////
    namespace ConsoleApplication1
    {
    
        interface iContravariance<in T>
        {
            void Info(T  t);
        }
    
        class Master<T> : iContravariance<T>
        {
           
            public void Info(T insT)
            {
    
                if (insT is Parent) {
                    WriteLine("--- As Parent: ---");
                    WriteLine((insT as Parent).Method());
                }
    
                if (insT is Child) {
                    WriteLine("--- As Child: ---") ;
                    WriteLine((insT as Child).Method()); 
                }
            }
        }
    
        class Parent {
    
            public virtual String Method()
            {
                WriteLine("Parent Method()");
                return "";
            }
    
        }
    
        class Child : Parent    {
    
            public override String Method()
            {
                WriteLine("Child Method()");
                return "";
            }
        }
    
        class Client
        {
            static void Main(string[] args)
            {
                Child child      = new Child();
                Parent parent = new Parent();
    
                iContravariance<Parent> interP = new Master<Parent>();
                iContravariance<Child>   interC = interP;
                            
                interC.Info(child);
    
                //interC.Info(parent); (It is compilation error.)
    
                ReadKey();
                return;
            }
        }
    }
