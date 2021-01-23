    using System;
    using System.Collections.Generic;
    
    namespace Variables
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                var dict = new Dictionary<string, int>();
                do
                {
                    //Print command
                    string command = Console.ReadLine();
                    if (command.ToLowerInvariant().StartsWith("print: "))
                    {
                        string p2 = command.Substring(command.IndexOf(' ') + 1);
                        if (dict.ContainsKey(p2)) Console.WriteLine(dict[p2]);
                        else Console.WriteLine("Variable {0} undefined!");
                    }
                    if (command.ToLowerInvariant().StartsWith("var "))
                    {
                        string v2 = command.Substring(command.IndexOf(' ') + 1);
                        string[] parts = v2.Split(new char[]{'='}, 2,  StringSplitOptions.RemoveEmptyEntries);
                        parts[0] = parts[0].Trim();
                        parts[1] = parts[1].Trim();
                        dict.Add(parts[0], int.Parse(parts[1]));
                    }
                }
                while (true);
            }
        }
    }
