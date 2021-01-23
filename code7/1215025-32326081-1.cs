    public void tictactoe(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        if (string.IsNullOrEmpty(b.Text)) {
	        b.Text = player;
        }
    }
