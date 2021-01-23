     class Program
        {
            static Dictionary<string, List<string>> Names = new Dictionary<string, List<string>>();
            static void Main(string[] args)
            {
                StreamReader File = new StreamReader("SSfile.txt");
                string line = File.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = File.ReadLine();
                    var names = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    Names.Add(names[0], names.Skip(1).ToList());
                }
                Console.ReadKey();
            }
    
            static bool canGive(giver, givee)
            {
               return Names[giver].Any(item => item == givee);
            }
        }
