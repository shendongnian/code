        public enum CardSuits
        {
            Clubs,
            Spades,
            Hearts,
            Diamonds
        }
        public enum CardValues
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4
        }
        
        public struct Card
        {
            public CardValues Value; // Card.Value = CardValues.Ace
            public CardSuits Suit; // Card.Suit = CardSuits.Spades
            
            public override string ToString()
            {
                // Card.ToString() == "Ace of Spades"
                return String.Format(Value + " of " + Suit); 
            }
            
            public string ToStringAsInteger()
            {
                // Card.ToStringAsInteger() == "1 of Spades"
                return String.Format((int)Value + " of " + Suit); 
            }
        }
        static void Main(string[] args)
        {
            Card AceOfSpades = new Card();
            AceOfSpades.Value = CardValues.Ace;
            AceOfSpades.Suit = CardSuits.Spades;
            Card TwoOfClubs = new Card();
            TwoOfClubs.Value = CardValues.Two;
            TwoOfClubs.Suit = CardSuits.Clubs;
            int mySum = (int)AceOfSpades.Value + (int)TwoOfClubs.Value;
            Console.WriteLine("Sum of Ace (1) and Two (2) is: " + mySum); // should be 3
            Console.WriteLine("output of AceOfSpades.ToString() is: " + AceOfSpades.ToString());
            Console.WriteLine("output of AceOfSpades.ToStringAsInteger is: " + AceOfSpades.ToStringAsInteger());
            Console.ReadKey();
        }
