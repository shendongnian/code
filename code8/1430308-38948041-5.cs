    public class Hand
    {
    	public IEnumerable<Card> Cards {get;set;}
    
    	public bool Contains(Value val)
    	{
    		return Cards.Where(c => c.Value == val).Any();
    	}
    	
    	public bool IsPair
    	{
    		get
    		{
    			return Cards.GroupBy(h => h.Value)
    					   .Where(g => g.Count() == 2)
    					   .Count() == 1;
    		}
    	}
    
    	public bool IsTwoPair
    	{
    		get
    		{
    			return Cards.GroupBy(h => h.Value)
    						.Where(g => g.Count() == 2)
    						.Count() == 2;
    		}
    	}
    
    	public bool IsThreeOfAKind
    	{
    		get
    		{
    			return Cards.GroupBy(h => h.Value)
    						.Where(g => g.Count() == 3)
    						.Any();
    		}
    	}
    
    	public bool IsFourOfAKind
    	{
    		get
    		{
    			return Cards.GroupBy(h => h.Value)
    						.Where(g => g.Count() == 4)
    						.Any();
    		}
    	}
    
    	public bool IsFlush
    	{
    		get
    		{
    			return Cards.GroupBy(h => h.Suit).Count() == 1;
    		}
    	}
    
    	public bool IsFullHouse
    	{
    		get
    		{
    			return IsPair && IsThreeOfAKind;
    		}
    	}
    
    	public bool IsStraight
    	{
    		get
    		{
    			// If there is an Ace, we have to handle the 10,J,Q,K,A case, which isn't handled by the code
    			// below because Ace is normally 0
    			if (Contains(Value.Ace) &&
    				Contains(Value.King) &&
    				Contains(Value.Queen) &&
    				Contains(Value.Jack) &&
    				Contains(Value.Ten))
    			{
    				return true;
    			}
    
    			var ordered = Cards.OrderBy(h => h.Value).ToArray();
    			var straightStart = (int)ordered.First().Value;
    			for (var i = 1; i < ordered.Length; i++)
    			{
    				if ((int)ordered[i].Value != straightStart + i)
    					return false;
    			}
    
    			return true;
    		}
    
    	}
    
    	public bool IsStraightFlush
    	{
    		get
    		{
    			return IsStraight && IsFlush;
    		}
    	}
    
    	public bool IsRoyalStraightFlush
    	{
    		get
    		{
    			return IsStraight && IsFlush && Contains(Value.Ace) && Contains(Value.King);
    		}
    	}
    }
    
    public class Deck
    {
    	public Deck()
    	{
    		var cards = new List<Card>();
    		foreach (Suit suit in Enum.GetValues(typeof(Suit)))
    		{
    			foreach (Value value in Enum.GetValues(typeof(Value)))
    			{
    				cards.Add(new Card { Suit = suit, Value = value });
    			}
    		}
    		Cards = cards;
    
    	}
    
    	public List<Card> Cards { get;}
    
    	public Hand DealStandardHand()
    	{
    		return new Hand { Cards = Cards.Take(5)};
    	}
    
    	private static Random rng = new Random();
    	public void Shuffle()
    	{
    		int n = Cards.Count;
    		while (n > 1)
    		{
    			n--;
    			int k = rng.Next(n + 1);
    			Card value = Cards[k];
    			Cards[k] = Cards[n];
    			Cards[n] = value;
    		}
    	}
    }
