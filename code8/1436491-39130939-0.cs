    using System;
    namespace ConsoleApplication99
    {
      class Program
      {
        class Class1
        {
          public int Id { get; set; }
          public string Name { get; set; }
          public string city { get; set; }
          public string email { get; set; }
        }
        static void Main(string[] args)
        {
          Class1 n = new Class1 { Id = 1, Name = "salis", city = "KhANPUR", email = "ASDASDASDA" };
          foreach (var fieldInfo in n.GetType().GetProperties())
          {
            var propName = fieldInfo.Name;
            Console.WriteLine(propName); // use fieldInfo.GetValue(n) to get Values
          }
        }
      }
    }
