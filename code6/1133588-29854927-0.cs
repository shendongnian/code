    public enum CardSuit
    {
      Hearts   = 1 ,
      Spades   = 2 ,
      Diamonds = 3 ,
      Clubs    = 4 ,
    }
    public enum CardValue {
      Ace    =  1 ,
      Two    =  2 ,
      Three  =  3 ,
      Four   =  4 ,
      Five   =  5 ,
      Six    =  6 ,
      Seven  =  7 ,
      Eight  =  8 ,
      Nine   =  9 ,
      Ten    = 10 ,
      Jack   = 11 ,
      Queen  = 12 ,
      King   = 13 ,
    }
    
    public class Card : IEquatable<Card> , IComparable<Card>
    {
      public readonly CardSuit  Suit  ;
      public readonly CardValue Value ;
      public Card( CardSuit suit , CardValue value )
      {
        if ( ! Enum.IsDefined(typeof(CardSuit),suit)   ) throw new ArgumentOutOfRangeException("suit") ;
        if ( ! Enum.IsDefined(typeof(CardValue),value) ) throw new ArgumentOutOfRangeException("value") ;
        
        this.Suit  = suit ;
        this.Value = value ;
        
        return;
      }
      
      public override int GetHashCode()
      {
        int value = ((int)this.Suit  << 16         )
                  | ((int)this.Value &  0x0000FFFF )
                  ;
        return value.GetHashCode() ;
      }
      
      public bool Equals( Card other )
      {
        return this.Suit == other.Suit && 0 == CompareTo(other) ;
      }
      
      public int CompareTo( Card other )
      {
        int cc = Math.Sign( (int)this.Value - (int) other.Value ) ;
        return cc;
      }
    }
    
    public class DeckOfCards
    {
      private static Random rng = new Random() ;
      private readonly IList<Card> cards ;
      
      public DeckOfCards()
      {
        this.cards = new List<Card>(52) ;
        foreach( CardSuit suit in Enum.GetValues(typeof(CardSuit)) )
        {
          foreach( CardValue value in Enum.GetValues(typeof(CardValue)) )
          {
            cards.Add(new Card(suit,value));
          }
        }
        
      }
      
      public void Shuffle()
      {
        // Fisher-Yates (Durtensfeld) shuffle algorithm: http://en.wikipedia.org/wiki/Fisher-Yates_shuffle
        for ( int i = 0 ; i < cards.Count ; ++i )
        {
           int  j   = rng.Next(i,cards.Count) ;
           Card t   = cards[j] ;
           cards[j] = cards[i] ;
           cards[i] = t        ;
        }
        return;
      }
      
    }
