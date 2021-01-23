	public class Card
	{
		private int value;
		private int suit;
		public Card(int ranvalue, int ransuit)
		{
			value = ranvalue;
			suit = ransuit;
		}
		public override string ToString()
		{
			var values = new []
			{
				"ace", "two", "three", "four", "five", "six", "seven",
				"eight", "nine", "ten", "jack", "queen", "king"
			};
			var suits = new []
			{
				"Hearts", "Spades", "Diamonds", "Clubs"
			};
			return String.Format("{0} of {1}", values[value - 1], suits[suit - 1]);
		}
	}
	
	public class Deck
	{
		private Random rng = new Random();
		private Card[] deck;
		
		public Deck()
		{
			deck =
			(
				from value in Enumerable.Range(1, 13)
				from suit in Enumerable.Range(1, 4)
				select new Card(value, suit)
			).ToArray();
		}
		
		public string deal(int number)
		{
			string dealt = string.Join(" ", deck.OrderBy(x => rng.Next()).Take(number));
			return dealt;
		}
	}
