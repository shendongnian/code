    public class Deck
    {
        //This needs to be public on the get side to be visible outside
        //of the Deck object
        public IList<Card> Cards { get; private set; }
    
        public Deck()
        {
            NewDeck();
        }
    
        #region Helper Methods
    
        private void NewDeck()
        {
            Cards = new List<Card>();
    
            for (var i = 0; i < 4; i++)
            {
                //Start your index at 2 since you enum starts at Two = 2
                //just as an FYI it's bad practice to not start an enum
                //without a zero based answer.
                for (var j = 2; j < 13; j++)
                {
                    Cards.Add(new Card {Suit = (Suit)i, Value = (CardValue)j } );
                }
            }
        }
        
        #endregion Helper Methods
    }
    
    public enum Suit
    {
        Spades, 
        Hearts, 
        Clubs, 
        Diamonds
    }
    
    public enum CardValue
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 10,
        Queen = 10,
        King = 10,
        Ace = 11
    
    }
    public class Card
    {
        public Suit Suit { get; set; }
        public CardValue Value { get; set; }
    
        //Tell your card class how to turn into a string representation
        public override string ToString()
        {
    
            return $"{Value} of {Suit}"; //This is C# 6
            //return string.Format("{0} of {1}", Value, Suit); <-- if less than C#6
        }
    }
