    public class Form1()
    {
        //Code
        private string _playerName;
        public Form1(string playerName)
        {
            this._playerName = playerName;
        }
        private void labelClick(object sender, EventArgs e)
        {
            Label clickedLabel = (Label)sender;
            if (clickedLabel.BackColor != Color.Transparent)
                return;
            
            clickedLabel.BackColor = isBlackTurn ? Color.Black : Color.White;
            isBlackTurn = !isBlackTurn;
            Color? winner = WinCheck.CheckWinner(board);
            if (winner == Color.Black)
                MessageBox.Show(this._playerName + " is the winner!");
            else if (winner == Color.White)
                MessageBox.Show("White is the winner!");
        }
        //More code
    }
    public class Form2()
    {
        public void ShowFormWinner()
        {
            var frm = new Form1(textBox1.Text);
            frm.Show();
        }
    }
