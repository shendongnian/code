    using System;
    using System.Collections.Generic;
    
        namespace ConsoleApplication3
        {
            public class Minion
            {
                public string name { get; set; }
                public int manaCost { get; set; }
                public int attack { get; set; }
                public int health { get; set; }
                public string cardText { get; set; }
        
                public void displayStats()
                {
                    Console.WriteLine(name + "\nMana Cost: " + manaCost + "\nAttack: " + attack + "\nHealth: " + health + "\n" + cardText + "\n");
                }
        
                class Program
                {
                    static void Main(string[] args)
                    {
                        var minionList = new List<Minion>();
        
                        minionList.Add(new Minion() { name = "Wolfrider", attack = 3, cardText = "Charge", health = 3, manaCost = 3 });
                        minionList.Add(new Minion() { name = "GoldShire Footman", attack = 1, cardText = "Taunt", health = 1, manaCost = 2 });
        
                        //look through all my cards
                        foreach (var minion in minionList)
                            minion.displayStats();
                        Console.ReadLine();
                    }
                }
            }
        }
