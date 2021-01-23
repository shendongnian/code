    public class Program
    {
        static void Main()
        {
            var b = new ClassB();
            ClassA.WhateverA = new List<string> { "this", "is", "whatever" };
            Console.ReadLine();
        }
    }
