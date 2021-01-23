    private void winner()
    {
    if (player2turn == false)
      {
       timer1.Stop();
       MessageBox.Show("Player 2 wins!", "Retry?", MessageBoxButtons.YesNo);
       gameover = true;
      }
    else
      {
       timer1.Stop();
       MessageBox.Show("Player 1 wins!", "Retry?", MessageBoxButtons.YesNo);
       gameover = true;
      }
    }
