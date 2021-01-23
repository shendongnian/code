    using NUnitLite;
    using System;
    using System.Reflection;
    
    namespace MyDnxProject.Test
    {
      public class Program
      {
        public int Main(string[] args)
        {
          var writter = new ExtendedTextWrapper(Console.Out);
          new AutoRun(typeof(Program).GetTypeInfo().Assembly).Execute(args, writter, Console.In);
        }
      }
    }
