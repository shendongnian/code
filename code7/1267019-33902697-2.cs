    using System;
    
    class Program
    {
        interface IBase<T>
        {
            void SomeMethod();
        }
    
        class SubClass1 : IBase<string>
        {
            public void SomeMethod()
            {
                Console.WriteLine("I write string!");
            }
        }
    
        class SubClass2 : IBase<int>
        {
            public void SomeMethod()
            {
                Console.WriteLine("I write int!");
            }
        }
    
        static void Main(string[] args)
        {
            IBase<string> instance1 = new SubClass1();
            IBase<int> instance2 = new SubClass2();
            instance1.SomeMethod(); //this should call SomeMethod<string>()
            instance2.SomeMethod(); //this should call SomeMethod<int>()
    
            Console.ReadLine();
        }
    }
