    public void tictactoe(object sender, EventArgs e)
    {
        var button = (Button)sender;
        if (button.Text == "")
            button.Text = player;
    }
