    public enum Suit
    {
    	Clubs,
    	Diamonds,
    	Hearts,
    	Spades
    }
    
    public enum Value
    {
    	Ace,
    	Two,
    	Three,
    	Four,
    	Five,
    	Six,
    	Seven,
    	Eight,
    	Nine,
    	Ten,
    	Jack,
    	Queen,
    	King
    }
    
    public class Card
    {
    	public Suit Suit { get; set; }
    	public Value Value { get; set; }
    }
