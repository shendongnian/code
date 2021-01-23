    public static void Main()
    {
        var deck = new BlackJackDeck();
        
        deck.Shuffle();
        
        foreach (var card in deck.Cards)
        {
            Console.WriteLine(card.ToString());
        }
    }
    public class BlackJackDeck
    {
        private const int DECKSIZE = 52;
        private Random random;
    
        //Card is your key, and int is the value of the card
        public IList<BlackJackCard> Cards { get; private set; }
    
    
        public BlackJackDeck()
        {
            random = new Random();
            NewDeck();
        }
    
        public void Shuffle()
        {
            //Documentation: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
            for (var i = 0; i < Cards.Count; i++)
            {
                var position = random.Next(i);
                var temp = Cards[i];
                Cards[i] = Cards[position];
                Cards[position] = temp;
            }
        }
    
        #region Helper Methods
    
        private void NewDeck()
        {
            Cards = new List<BlackJackCard>(DECKSIZE);
    
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 13; j++)
                {
                    switch (j)
                    {
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            Cards.Add(new BlackJackCard { Suit = (Suit)i, Face = (CardFace)j, Value = 10});
                            break;
                        case 12:
                            Cards.Add(new BlackJackCard { Suit = (Suit)i, Face = (CardFace)j, Value = 11});
                            break;
                        default:
                            Cards.Add(new BlackJackCard { Suit = (Suit)i, Face = (CardFace)j, Value = (j + 2)});
                            break;
                    }
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
    
    public enum CardFace
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
    
    public class BlackJackCard : Card
    {
        public int Value { get; set; }
    
        public override string ToString()
        {
            //MSDN Documentation: https://msdn.microsoft.com/en-us/library/dn961160.aspx
            //base.ToString() is the Card classes ToString()
            return $"{base.ToString()} with value: {Value}";
        }
    }
    
    //this is for making a basic card and deck of cards
    //Inherit from this to create cards specific to different game rules, i.e BlackJack, Go Fish, etc
    //Documentation: https://msdn.microsoft.com/en-us/library/k535acbf(v=vs.71).aspx
    public abstract class Card
    {
        public Suit Suit { get; set; }
        public CardFace Face { get; set; }
    
        public override string ToString()
        {
            return $"{Face} of {Suit}";
        }
    }
