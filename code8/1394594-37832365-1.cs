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
    public class MainClass
    {
        internal void Run()
        {
            EventHandleClass class1 = new EventHandleClass();
            class1.Example += Class1_Example;
            class1.CheckEventInfo();
        }
        private void Class1_Example(object sender, EventArgs e)
        {
            Console.WriteLine("Class1_Example Method: ");
        }
        public string WhateverName { get; set; }
    }
