     for (int i = 0; i < 4; i++)
        {
             c1=0;
             c2=0;
            for (int k = 0; k < 5; k++)
            {
                if (PokerCard[k] == two[i] && c1==0)
                {
                    PokerTwo++;
                    c1++;
                }
                if (PokerTwo == 2 && c2==0)
                {
                    cash = cash + 10;
                    winnings = winnings + 10;
                    Cash.Text = Convert.ToString(cash);
                    Winnings.Text = Convert.ToString(winnings);
                    PairWin.BackColor = Color.Red;
                    Winner.Visible = true;
                    c2++;
                 }
               }
              }
