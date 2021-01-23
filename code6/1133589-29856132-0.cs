    public class Card
	{
		//Declaration of fields
		private static char[] suits = new char[] { 'D', 'H', 'S', 'C' };    //Backing Variables
		private static char[] values = new char[]{'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K'};
		private readonly char suit;
		private readonly char value;
		static Random random = new Random();
		public Card() //Constructor
		{
			int suitIndex = random.Next(0, suits.Length);
			suit = suits[suitIndex];
			int valueIndex = random.Next(0, values.Length);
			value = values[valueIndex];
		}
		public char Suit //Properties
		{
			get { return suit; }
		}
		public char Value
		{
			get { return value; }
		}
	}
