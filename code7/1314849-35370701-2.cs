    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace TestingC
    {
    public class Program
      {
        public const string apple = "good!";
        public static void First()
        {
            Console.WriteLine("Apple is: " + apple);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Apple is: " + apple);
            Console.ReadLine();
            First();
            Console.WriteLine("Apple is: " + apple);
            Console.ReadLine();
        }
      }
    }
