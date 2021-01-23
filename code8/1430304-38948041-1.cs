    public static class HandExtensions
    {
    	public static bool IsPair(this IEnumerable<Card> hand)
    	{
    		return hand.GroupBy(h => h.Value)
    				   .Where(g => g.Count() == 2)
    				   .Count() == 1;
    	}
    
    	public static bool IsTwoPair(this IEnumerable<Card> hand)
    	{
    		return hand.GroupBy(h => h.Value)
    					.Where(g => g.Count() == 2)
    					.Count() == 2;
    	}
    
    	public static bool IsThreeOfAKind(this IEnumerable<Card> hand)
    	{
    		return hand.GroupBy(h => h.Value)
    					.Where(g => g.Count() == 3)
    					.Any();
    	}
    
    	public static bool IsFourOfAKind(this IEnumerable<Card> hand)
    	{
    		return hand.GroupBy(h => h.Value)
    					.Where(g => g.Count() == 4)
    					.Any();
    	}
    	
    	public static bool IsFlush(this IEnumerable<Card> hand)
    	{
    		return hand.GroupBy(h => h.Suit).Count() == 1;
    	}
    	
    	public static bool IsStraight(this IEnumerable<Card> hand)
    	{
    		
    		var ordered = hand.OrderBy(h => h.Value).ToArray();
    		var straightStart = (int)ordered.First().Value;
    		for (var i = 1; i < ordered.Length; i++)
    		{
    			if ((int)ordered[i].Value != straightStart + i)
    				return false;
    		}
    		
    		return true;
    		
    	}
    
    	public static bool IsFullHouse(this IEnumerable<Card> hand)
    	{
    		return hand.IsPair() && hand.IsThreeOfAKind();
    	}
    	
    	public static bool IsStraightFlush(this IEnumerable<Card> hand)
    	{
    		return hand.IsStraight() && hand.IsFlush();
    	}
    }
