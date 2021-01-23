    public void getOtherTextBox()
    {
        otherForm.TextBox1.Text = player1;
    }
    private void labelClick(object sender, EventArgs e)
    {
        Label clickedLabel = (Label)sender;
        getOtherTextBox();
        if (clickedLabel.BackColor != Color.Transparent)
        {
            return;
        }
        clickedLabel.BackColor = isBlackTurn ? Color.Black : Color.White;
        isBlackTurn = !isBlackTurn;
        Color? winner = WinCheck.CheckWinner(board);
        if (winner == Color.Black)
        {
            MessageBox.Show(  player1 + " is the winner!");
        }
        else if (winner == Color.White)
        {
            MessageBox.Show("White is the winner!");
        }
        else
        {
            return;
        }
}
