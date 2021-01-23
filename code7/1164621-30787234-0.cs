    string action = @"
    using System;
        namespace HelloWorld
        {
            class HelloWorldClass
            {
                  static void Main(string[] args)
                  {
                       //pay attention to the @ next to hello world
                       Console.WriteLine(""" + @"Hello World!""" + @");
                       Console.ReadLine();
                  }
            }
         }
    ";
