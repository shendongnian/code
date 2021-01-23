    using System;
    using System.Text;
    using System.Runtime.Serialization;
     
    class Program
    {
      static void Main(string[] args)
      {
        ObjectIDGenerator idGenerator = new ObjectIDGenerator();
        bool blStatus = new bool();
        //just ignore this blStatus Now.
        String str = "My first string was ";
        Console.WriteLine("str = {0}", str);
        Console.WriteLine("Instance Id : {0}", idGenerator.GetId(str, out blStatus));
        //here blStatus get True for new instace otherwise it will be false
        Console.WriteLine("this instance is new : {0}\n", blStatus);
        str += "Hello World";
        Console.WriteLine("str = {0}", str);
        Console.WriteLine("Instance Id : {0}", idGenerator.GetId(str, out blStatus));
        Console.WriteLine("this instance is new : {0}\n", blStatus);
        //Now str="My first string was Hello World"
        StringBuilder sbr = new StringBuilder("My Favourate Programming Font is ");
        Console.WriteLine("sbr = {0}", sbr);
        Console.WriteLine("Instance Id : {0}", idGenerator.GetId(sbr, out blStatus));
        Console.WriteLine("this instance is new : {0}\n", blStatus);
        sbr.Append("Inconsolata");
        Console.WriteLine("sbr = {0}", sbr);
        Console.WriteLine("Instance Id : {0}", idGenerator.GetId(sbr, out blStatus));
        Console.WriteLine("this instance is new : {0}\n", blStatus);
        //Now sbr="My Favourate Programming Font is Inconsolata"
        Console.ReadKey();
      }
    }
