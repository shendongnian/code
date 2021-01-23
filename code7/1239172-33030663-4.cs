	class Deck
	{
		private Card[] cards;
	
		public Deck()
		{
			var query =
				from suit in new [] { "Spades", "Hearts", "Clubs", "Diamonds", }
				from rank in Enumerable.Range(1, 13)
				select new Card(rank, suit);
				
			cards = query.ToArray();
		}
	}
