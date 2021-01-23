    public class PokerTwoStrategy : IStrategy
    {
        public bool IsApplicable(YourClass instance)
        {
            return instance.PokerTwo == 2;
        }
        public void Apply(YourClass instance)
        {
            instance.cash = cash + 10;
            instance.winnings = winnings + 10;
            instance.Cash.Text = Convert.ToString(cash);
            instance.Winnings.Text = Convert.ToString(winnings);
            instance.PairWin.BackColor = Color.Red;
            instance.Winner.Visible = true;
        }
    }
