    using System.Linq;
    
    char[] Delimiters = new char[] { ',' };
    string[] Input = Console.ReadLine().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
    Input.ToList().ForEach(Console.WriteLine);
