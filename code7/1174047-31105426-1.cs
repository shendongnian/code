    using System;
    
    using COMStructProviderLib;
    
    namespace CSharpCOMClient
    {
        class Program
        {
            static void Main(string[] args)
            {
                IMyStruct mystruct = new MyStruct();
                mystruct.setName("John");
                String name = mystruct.getName();
                Console.WriteLine(name);
                mystruct.setAge(5);
                long age = mystruct.getAge();
                Console.WriteLine(age);
            }
        }
    }
