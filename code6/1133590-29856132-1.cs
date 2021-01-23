    class Program
	{
		static void Main(string[] args)
		{
			Card aCard = new Card();
			Console.WriteLine("Suit: {0}", aCard.Suit);
			Console.WriteLine("Value: {0}", aCard.Value);
			Console.Read();
		}
	}
