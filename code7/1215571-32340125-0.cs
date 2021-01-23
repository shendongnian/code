    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    namespace ConsoleApplication45
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<card> cards = new List<card>();
                string input = "C 13 H 13 D 13 C 10 H 10";
                string[] inputArray = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for(int i = 0; i < 10; i += 2)
                {
                    card newCard = new card();
                    newCard.suit = inputArray[i][0];
                    newCard.value = int.Parse(inputArray[i + 1]);
                    cards.Add(newCard);
                }
     
            }
            public struct card
            {
                public char suit; // 'C', 'D', 'H', 'S' - for clubs, diamonds, hearts, and spades    
                public int value; //2-14 – for 2-10,Jack, Queen, King, Ace };
            }
        }
      
    }
