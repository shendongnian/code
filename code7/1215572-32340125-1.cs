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
                List<Card> cards = new List<Card>();
                string input = "C 13 H 13 D 13 C 10 H 10";
                string[] inputArray = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for(int i = 0; i < 10; i += 2)
                {
                    Card newCard = new Card();
                    newCard.suit = inputArray[i][0];
                    newCard.value = int.Parse(inputArray[i + 1]);
                    cards.Add(newCard);
                }
                foreach (Card card in cards)
                {
                    Console.WriteLine("Suit {0}, Rank {1}", card.suit, card.value.ToString());
                }
                Console.ReadLine();
     
            }
            public struct Card
            {
                public char suit; // 'C', 'D', 'H', 'S' - for clubs, diamonds, hearts, and spades    
                public int value; //2-14 – for 2-10,Jack, Queen, King, Ace };
            }
        }
      
    }
