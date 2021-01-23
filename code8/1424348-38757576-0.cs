    using System;
    
    namespace tests
    {
        public interface ILevel1
        {
            int a { get; set; }
            int b { get; set; }
            string c { get; set; }
        }
    
        public interface ILevel2a
        {
            string d { get; set; }
            int e { get; set; }
        }
    
        public interface ILevel2b
        {
            int f { get; set; }
            bool g { get; set; }
        }
    
        public class Level2a : ILevel1, ILevel2a {
            int ILevel1.a { get; set; }
            int ILevel1.b { get; set; }
            string ILevel1.c { get; set; }
    
            string ILevel2a.d { get; set; }
            int ILevel2a.e { get; set; }
        }
    
        public class Level2b : ILevel1, ILevel2b
        {
            int ILevel1.a { get; set; }
            int ILevel1.b { get; set; }
            string ILevel1.c { get; set; }
    
            int ILevel2b.f { get; set; }
            bool ILevel2b.g { get; set; }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                Level2a myObjectA = new Level2a();
                Level2b myObjectB = new Level2b();
    
                ((ILevel1)myObjectA).c = "This is ";
                ((ILevel2a)myObjectA).d = "my string";
    
                ((ILevel1)myObjectB).c = "Hey, I'm a Level2b!";
    
                int myVariable = 0;
    
                dynamic myObject = null; // declare as dynamic
    
                switch (myVariable)
                {
                case 0: myObject = myObjectA; break;
                case 1: myObject = myObjectB; break;
                default:
                    break;
                }
    
                if (myObject is Level2a)
                {
                    Console.WriteLine(((ILevel1)myObject).c + ((ILevel2a)myObject).d);
                }
                else if (myObject is Level2b)
                {
                    Console.WriteLine(((ILevel1)myObject).c);
                }
    
                Console.ReadKey();
            }
        }
    }
