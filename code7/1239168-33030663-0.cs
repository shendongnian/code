	class Deck
	{
		private Card[] cards;
	
		public Deck()
		{
			cards =
				new [] { "Spades", "Hearts", "Clubs", "Diamonds", }
					.SelectMany(
						suit => Enumerable.Range(1, 13),
						(suit, rank) => new Card(rank, suit))
					.ToArray();
		}
	}
