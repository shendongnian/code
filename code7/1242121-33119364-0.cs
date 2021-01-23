    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace RockPaperScissors
    
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var choices = new Dictionary<int, string> { { 1, "Rock" }, { 2, "Paper" }, { 3, "Scissors" } };
                int input;
                var randomly = new Dictionary<int, string> { { 1, "Rock" }, { 2, "Paper" }, { 3, "Scissors" } };
    
                Random random = new Random();
                int RandomNumber = random.Next(1, 4);
                int Ties;
                int Wins;
                int Losses;
              
    
    
                do
                {
                    //Counter
                    Wins = 0;
                    Losses = 0;
                    Ties = 0;
                    Console.WriteLine("-- Weapons Menu --");
                    Console.WriteLine("-------------------");
                    Console.WriteLine("1] Rock");
                    Console.WriteLine("2] Paper");
                    Console.WriteLine("3] Scissors");
                    Console.WriteLine("Choose Your Weapon [1, 2 or 3]:");
                    input = int.Parse(Console.ReadLine());
                    if (input == RandomNumber)
                        Console.WriteLine("You Tied The Computer");
                    Ties++;
                    //Winning 
                    if (input == 1 && RandomNumber == 3)
                        
                    Console.WriteLine("You Beat The Computer :)");
                    Wins++;
    
                    if (input == 2 && RandomNumber == 1)
                        
                    Console.WriteLine("You Beat The Computer :)");
                    Wins++;
    
                    if (input == 3 && RandomNumber == 2)
                        
                    Console.WriteLine("You Beat The Computer :)");
                    Wins++;
    
    
                    //Lossing 
                    if (input == 1 && RandomNumber == 2)
                        
                        Console.WriteLine("Sorry You Lost To The Computer :(");
                    Losses++;
    
                    if (input == 2 && RandomNumber == 3)
                        
                    Console.WriteLine("You Beat The Computer :)");
                    Losses++;
    
                    if (input == 3 && RandomNumber == 1)
                      
                    Console.WriteLine("You Beat The Computer :)");
                    Losses++;
    
    
    
    
    
    
    
    
    
    
                    Console.WriteLine(string.Format("Player Chose {0} : Computer Chose {1}", choices[input], randomly[RandomNumber]));
                    Console.WriteLine();
                    Console.WriteLine("<Press Any Key To Continue...>");
                    Console.WriteLine();
                    
    
                    
                    Console.WriteLine("Player Wins      Computer Wins");
                    Console.WriteLine("----------       --------------");
                    Console.WriteLine(" {0}                {1}", Wins, Losses);
    
    
                    
    
                    Console.ReadKey();
                    }
                    while (input != 3) ;
                    Console.WriteLine("Thanks for playing!");
                }enter code here
        }
        }
    
       
                
           STILL CANNOT SHOW THE COUNTER WHY     
