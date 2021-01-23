      public class Card {
        public Card (CardSuit suit, CardValue value) {
          Suit = suit;
          Value = value;  
        }
    
        public CardSuit Suit {get; private set;} 
        public CardValue Value {get; private set;} 
      }
    
      ...
    
      Card[] pack = Enum
        .GetValues(typeof(CardSuit))
        .OfType<CardSuit>()
        .SelectMany(suit => Enum
          .GetValues(typeof(CardValue))
          .OfType<CardValue>()
          .Select(value => new Card(suit, value)))
        .ToArray();
      //TODO: Shuffle the pack here
      Card[] hand = pack.Take(5).ToArray();
      int handValue = hand.Sum(card => card.Value.ActualValue()); 
