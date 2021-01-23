    public class Context
    {
        public Player Player;
        public Player TargetPlayer;
        public ChipStack ChipStack;
        ...
    }
    
    public abstract class Card
    {
        public abstract void Action(Context c);
    }
    
    ...
    
    public class Duke : MoneyCard
    {
        public override void Action(Context c)
        {
            for (int i = 0; i < 3; i++)
            {
                c.Player.TakeChip(c.ChipStack);
            }
        }
    
        public override string ToString()
        {
            return "Duke";
        }
    }
    
    public void CardAction(Card card)
    {
        var c = new Context { Player = p1, TargetPlayer = p2, ChipStack = chips };
        card.Action(c);
    }
