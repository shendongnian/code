    using System;
    
    class Program
    {
        interface IBase
        {
            void SomeMethod();
        }
    
        class SubClass<T> : IBase
        {
            public void SomeMethod()
            {
                Console.WriteLine("I write {0}", typeof(T));
            }
        }
    
        static void Main(string[] args)
        {
            IBase instance1 = new SubClass<string>();
            IBase instance2 = new SubClass<int>();
            instance1.SomeMethod(); //this should call SomeMethod<string>()
            instance2.SomeMethod(); //this should call SomeMethod<int>()
    
            Console.ReadLine();
        }
    }
