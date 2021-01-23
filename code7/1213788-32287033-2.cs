    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Poker
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                var clubs = new List<int>();
                var hearts = new List<int>();
                var diamonds = new List<int>();
                var spades = new List<int>();
    
                var fileContent = "C 6 C 9 C 10 C 11 C 12";
    
                var parts = fileContent.Split(' ');
    
                for (int i = 0; i < parts.Length; i += 2)
                {
                    switch (parts[i])
                    {
                        case "C": clubs.Add(Int32.Parse(parts[i + 1])); break;
                        case "H": hearts.Add(Int32.Parse(parts[i + 1])); break;
                        case "D": diamonds.Add(Int32.Parse(parts[i + 1])); break;
                        case "S": spades.Add(Int32.Parse(parts[i + 1])); break;
                        default:
                            break;
                    }
                }
    
                Console.WriteLine("Clubs: {0}", string.Join(" ", clubs));
                Console.WriteLine("Hearts: {0}", string.Join(" ", hearts));
                Console.WriteLine("Diamonds: {0}", string.Join(" ", diamonds));
                Console.WriteLine("Spades: {0}", string.Join(" ", spades));
    
                Console.ReadLine();
            }
        }
    }
