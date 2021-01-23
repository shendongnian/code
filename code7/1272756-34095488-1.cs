    public class Form1()
    {
        //Code
        private string PlayerName { get; set; }
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
        private Form1 _frm;
        public Form2()
        {
            this._frm = new Form1();
        }
        public void ShowFormWinner()
        {
            _frm.PlayerName = textBox1.Text;
            _frm.Show();
        }
        public void OnPlayerNameChanged(object sender, EventArgs e)
        {
            _frm.PlayerName = textBox1.Text;
            _frm.Show();
        }
    }
