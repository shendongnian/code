      public static IEnumerable<string> My()
      {
          var mystring = new List<string>();
          mystring.Add("aaaa");
          mystring.Add("bbb");
          return mystring;
      }
      private static void Main(string[] args)
      {
          var test = My();
          Console.WriteLine(string.Join(",", test.ToArray()));
           
          Console.WriteLine("Press any key to continue.");
          Console.ReadLine();
      }
