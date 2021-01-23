    private void winner()
     {
    
      if (player2turn == false)
         {
           gameover = true;
           MessageBox.Show("Player 2 wins!", "Retry?", MessageBoxButtons.YesNo);       
          }
      else
          {
           gameover = true;
           MessageBox.Show("Player 1 wins!", "Retry?", MessageBoxButtons.YesNo);       
          }
      }
