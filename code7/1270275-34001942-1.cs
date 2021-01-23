    public class Card
    {
         public string Name { get; private set; }
 
         /* cards have a value of 2-14 */
         public int Value { get; private set; }
    }
    public abstract class Rule()
    {
          public abstract string Name { get; }
  
          /* hands are calculated in powers of 100, when the card value is added you will get something like 335 */
          public abstract int Value { get; }
          public abstract bool HasHand(IReadonlyList<Card> cards);
    }
    public class PairRule() : Rule
    {
         public override string Name
         {
             get { return "Pair"; }
         }
         public override int Value
         {
             get { return 100; }
         }
         public override bool HasHand(IReadonlyList<Card> cards)
         {
              /* implement rule here */
              return Enumerable.Any(
                  from x in cards
                  group x by x.Value into g
                  where g.Count() == 2
                  select g
              );
         }  
    }
    
    ...
    public class Player
    {
         public IReadonlyList<Card> Hand { get; private set; }
         public int GetHandValue(IReadonlyList<Rule> rules)
         {
              /* get value of hand 100, 200, 300 etc. */
              var handValue = Enumerable.Max(
                   from x in rules
                   where x.HasHand(Hand)
                   select x.Value
              );
                   
              /* get value of cards */
              var cardValue = Hand
                   .OrderByDescending(x => x.Value)
                   .Take(5)
                   .Sum();
              
              return handValue + cardValue;
         }
    }
    public class Pot
    {
         public int Value { get; private set; }
         public IReadonlyList<Player> Players { get; private set; }
         public IReadonlyList<Player> GetWinners(IReadonlyList<Rule> rules)
         {
              var playerHands = Enumerable.ToList(
                  from x in players
                  select new {
                      Player = x,
                      HandValue = x.GetHandValue(rules)
                  }
              );
              var maxHand = playerHands.Max(x => x.HandValue);
              return Enumerable.ToList(
                  from x in playerHands
                  where x.HandValue == maxHand
                  select x.Player
              );
         }
    }
