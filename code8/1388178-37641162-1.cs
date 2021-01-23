	void Main()
	{
		//Define
		Deal dc = new Deal();
		// write string repersentation 
		// enum
	
	
		Console.WriteLine("Please Enter the amount you would like to bet 1-5");
		float bet = float.Parse(Console.ReadLine());
	
		if (bet < 0)
		{
			Console.WriteLine("Please enter valid bet amount");
		}
		else
		{
			dc.DealSetup();
		}
	
	
		if (bet > 5)
		{
			Console.WriteLine("Please enter higher bet amount");
		}
		else
		{
			//dc.GetHand();
		}
	}
	
	class Deal
	{
		private DeckofCards Deck = new DeckofCards();
		
		private Card[] PlayerHand;
		private Card[] ComputerHand;
		private Card[] SortPHand; //sorted player hand
		private Card[] SortCHand; // sorted computer hand
	
	
		public Deal()
		{
			var selected = this.Deck.GetDeck.Take(10).Select((x, n) => new { x, n }).GroupBy(x => x.n % 2, x => x.x).ToArray();
			this.PlayerHand = selected[0].ToArray();
			this.ComputerHand = selected[1].ToArray();
		}
	
		public void DealSetup()
		{
			sortCards();
			evaluateHands();
		}
	
		public void sortCards()
		{
			this.SortPHand = this.PlayerHand.OrderBy(x => x.CardValue).ToArray();
			this.SortCHand = this.ComputerHand.OrderBy(x => x.CardValue).ToArray();
		}
		
		public void evaluateHands()
		{
			//create player's computer's evaluation objects (passing Sorted hand to constructor)
			HandEvaluator playerHandEvaluator = new HandEvaluator(SortPHand);
			HandEvaluator computerHandEvaluator = new HandEvaluator(SortCHand);
	
			//get the player's and computer's handj
			Hand playerHand = playerHandEvaluator.EvaluateHand();
			Hand computerHand = computerHandEvaluator.EvaluateHand();
	
			//display each hand
			Console.WriteLine("\n\n\n\n\nPlayer's Hand: " + playerHand);
			foreach (var card in PlayerHand)
			{
				Console.Write(card.CardValue.ToString());
				Console.Write(" of ");
				Console.Write(card.CardSuit.ToString());
				Console.Write("\n");
			}
			Console.WriteLine("\n\n\n\n\nComputer's Hand: " + computerHand);
	
			foreach (var card in ComputerHand)
			{
				Console.Write(card.CardValue.ToString());
				Console.Write(" of ");
				Console.Write(card.CardSuit.ToString());
				Console.Write("\n");
			}
			//evaluate hands
			if (playerHand > computerHand)
			{
				Console.WriteLine("Player WINS!");
			}
			else if (playerHand < computerHand)
			{
				Console.WriteLine("Computer WINS!");
			}
			else //if the hands are the same, evaluate the values
			{
				//first evaluate who has higher value of hand
				if (playerHandEvaluator.HVs.Total > computerHandEvaluator.HVs.Total)
					Console.WriteLine("Player WINS!");
				else if (playerHandEvaluator.HVs.Total < computerHandEvaluator.HVs.Total)
					Console.WriteLine("Computer WINS!");
				//if both hanve the same poker hand 
				// player with the next higher card wins
				else if (playerHandEvaluator.HVs.HighCard > computerHandEvaluator.HVs.HighCard)
					Console.WriteLine("Player WINS!");
				else if (playerHandEvaluator.HVs.HighCard < computerHandEvaluator.HVs.HighCard)
					Console.WriteLine("Computer WINS!");
				else
					Console.WriteLine("Draw, no one wins!");
			}
		}
	}
	
	class DeckofCards
	{
		private Card[] Deck;
	
		public DeckofCards()
		{
			var cards =
				from s in Enum.GetValues(typeof(Card.SUIT)).Cast<Card.SUIT>()
				from v in Enum.GetValues(typeof(Card.VALUE)).Cast<Card.VALUE>()
				select new Card { CardSuit = s, CardValue = v };
			this.Deck = cards.ToArray();
			this.Shuffle();
		}
	
		public Card[] GetDeck //grab current deck
		{
			get
			{ return Deck; }
		}
	
		private Random rand = new Random();
	
		public void Shuffle()
		{
			this.Deck = this.Deck.OrderBy(x => rand.Next()).ToArray();
		}
	}
	
	
	public enum Hand
	{
		Nothing,
		OnePair, //Jacks or Better
		TwoPairs,
		ToK, //Three of a kind
		Str, //straight
		Flush,
		StrFlush, //straight flush
		FullH, // Full House 
		FoK, // Four of a  Kind 
		Royal, //Royal Flush                 
	}
	
	public struct HandValue
	{
		public int Total
		{
			get;
			set;
		}
		public int HighCard
		{
			get;
			set;
		}
	}
	
	class HandEvaluator
	{
		private Card[] cards;
		private HandValue HV; //Hand Value
	
		public HandEvaluator(Card[] SortedHand)
		{
			cards = SortedHand;
			HV = new HandValue();
		}
	
		public HandValue HVs { get { return HV; } set { HV = value; } }
	
		public Card[] Cards { get { return cards; } }
	
		public Hand EvaluateHand()
		{
			//gets number of each suit on hand
			if (Royal())
				return Hand.Royal;
			else if (FoK())
				return Hand.FoK;
			else if (FullH())
				return Hand.FullH;
			else if (StrFlush())
				return Hand.StrFlush;
			else if (Flush())
				return Hand.Flush;
			else if (Str())
				return Hand.Str;
			else if (ToK())
				return Hand.ToK;
			else if (TwoPairs())
				return Hand.TwoPairs;
			else if (OnePair())
				return Hand.OnePair;
	
			//if hand is nothing, player with highest card wins
			HV.HighCard = (int)cards[4].CardValue;
			return Hand.Nothing;
		}
	
		private bool Str()
		{
			var aceHigh = cards.Select(c => (int)c.CardValue).OrderBy(x => x).ToArray();
			var aceLow = aceHigh.Select(x => x == 14 ? 1 : x).ToArray();
	
			return new[] { aceHigh, aceLow }.Any(cs => cs.Skip(1).Zip(cs, (c1, c0) => c1 - c0).All(x => x == 1));
		}
	
		private bool Royal()
		{
			var firstIsTen = cards.Select(c => (int)c.CardValue).Min() == 10;
			return firstIsTen && this.StrFlush();
		}
	
		private bool FoK()
		{
			return cards.GroupBy(x => x.CardValue).Any(x => x.Count() == 4);
		}
	
		private bool FullH()
		{
			return cards.GroupBy(x => x.CardValue).Select(x => x.Count()).OrderBy(x => x).SequenceEqual(new[] { 2, 3 });
		}
	
		private bool StrFlush()
		{
			return this.Str() & this.Flush();
		}
	
		private bool Flush()
		{
			return cards.Select(x => x.CardSuit).Distinct().Count() == 1;
		}
	
		private bool ToK()
		{
			return cards.GroupBy(x => x.CardValue).Any(x => x.Count() == 3);
		}
	
		private bool TwoPairs()
		{
			return cards.GroupBy(x => x.CardValue).Select(x => x.Count()).OrderBy(x => x).SequenceEqual(new[] { 1, 2, 2 });
		}
	
		private bool OnePair()
		{
			return cards.GroupBy(x => x.CardValue).Select(x => x.Count()).OrderBy(x => x).SequenceEqual(new[] { 1, 1, 1, 2 });
		}
	}
	
	class Card
	{
		public enum SUIT
		{
			SPADE,
			HEART,
			DIAMOND,
			CLUB
		}
	
		public enum VALUE
		{
			TWO = 2, THREE, FOUR, FIVE, SIX,
			SEVEN, EIGHT, NINE, TEN,
			JACK, QUEEN, KING, ACE
		}
	
		public SUIT CardSuit { get; set; }
		public VALUE CardValue { get; set; }
		public bool IsFace
		{
			get
			{
				return (int)this.CardValue >= (int)VALUE.JACK;
			}
		}
	}	
