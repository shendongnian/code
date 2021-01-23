    public class Deck
	{
		private static char[] suits = new char[] { 'D', 'H', 'S', 'C' };   
		private static char[] values = new char[] { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K' };
		private readonly List<Card> cards;
		public Deck()
		{
			cards = new List<Card>();
			foreach (char suit in suits)
			{
				foreach (char value in values)
				{
					Card card = new Card(suit, value);
					cards.Add(card);
				}
			}
		}
		public List<Card> Cards { get { return cards; } }
	}
