    public class Card
    {
        public string Suit { get; private set; }
        public string Rank { get; private set; }
    
        public Card(string suit, string rank)
        {
            if (!(ValidSuits().Contains(suit) && ValidRanks().Contains(rank)))
            {
                Console.WriteLine("Error not such suit or rank found. Exiting...");
                Console.ReadLine();
                Environment.Exit(1);
            }
            else
            {
                this.Suit = suit;
                this.Rank = rank;
            }
        }
    
        public static string[] ValidSuits()
        {
            return new [] { "Hearts", "Spades", "Diamonds", "Clubs", };
        }
    
        public static string[] ValidRanks()
        {
    		var named = new [] { "Ace", "Jack", "Queen", "King" };
    		return named.Take(1).Concat(Enumerable.Range(2, 9).Select(n => n.ToString())).Concat(named.Skip(1)).ToArray();
        }
    
        public int GetValue()
        {
    		return Array.IndexOf(ValidRanks(), this.Rank) + 1;
        }
    
        public override string ToString()
        {
            return string.Format("{0} of {1}", this.Rank, this.Suit);
        }
    }
    
    public class Deck
    {
        public Card[] Cards { get; set; }
        private Random RandomGenerator = new Random();
    
        public Deck()
        {
            this.Cards = 
    		(
    			from rank1 in Card.ValidRanks()
    			from suit1 in Card.ValidSuits()
    			select new Card(suit1, rank1)
            ).ToArray();
        }
    
        public void Shuffle()
        {
            this.Cards = this.Cards.OrderBy(x => RandomGenerator.Next()).ToArray();
        }
    }
