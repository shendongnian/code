    // This class will create an instance of the MainClass.
    class Program
    {
        static void Main(string[] args)
        {
            MainClass mainClass = new MainClass();
            mainClass.WhateverName = "MyClass2 main";
            mainClass.Run();
            Console.ReadLine();
        }
    }
---
    // I'd rather use an interface
    public interface IMyClassInfo
    {
        string WhateverName { get; set; }
    }
