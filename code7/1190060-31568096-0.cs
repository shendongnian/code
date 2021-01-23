    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Hangman
    {
    class Program
      {
        static void Main(string[] args)
        {
            printWord();                                          
            
        }
        /*I created a method to perform this, so that I can have the program stay open for 
        either 1) a new game or 2) just to see if I could do it. It works!*/
        private static void printWord()
        {
            String[] myWordArrays = File.ReadAllLines("WordList.txt");
            Random randomWord = new Random();
            //int lineCount = File.ReadLines("WordList.txt").Count();
            //The line below fixed my previous issue of double-reading file            
            int activeWord = randomWord.Next(0, myWordArrays.Length);
            string userSelection = "";
            Console.WriteLine("Are you Ready to play Hangman? yes/no: ");
            userSelection = Console.ReadLine();
                if(userSelection == "yes")
                {
                    /*This runs through the randomly chosen word and prints an underscore in 
                    place of each letter - it does work and this is what fixed my 
                    previous issue - thank you Sven*/
                    foreach(char letter in myWordArrays[activeWord])
                    {
                Console.Write("_ ");
                    }
                    
                    //This prints to the console "Can you guess what this 'varyingLength' letter word is?" - it does work.
                    Console.WriteLine("Can you guess what this "+ myWordArrays[activeWord].Length +" letter word is?");
                    Console.ReadLine();
                } 
                //else if(userSelection=="no") -- will add more later
        }
        
      }
    }
