    namespace ConsoleApplication21
    {
        class Program
        {
            static void Main(string[] args)
            {
               var names = File.ReadLines("SSfile.txt")
                               .SelectMany(line => line.Split(' '));
    
               foreach(var name in names)
               {
                  Console.WriteLine(name);
               }
             }
         }
    }
