    private void btnRoll_Click(object sender, EventArgs e)
    {
        string message = game.RollDice();
        lblMessage.Text = message;
    }
