    private void button_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        if (button == null) return;
    
        button.Text= IsTurn();
    }
    private string IsTurn ()
        {
            if (turn==true)
            {
                textBlockGameInfo.Text = "It is " + playerO + "'s turn";
                turn = false;
                return "O";
            }
            else if (turn==false)
            {
                textBlockGameInfo.Text = "It is " + playerX + "'s turn";
                turn = true;
                return "X";
            }
        }
