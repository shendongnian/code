    public string[,] MoveComputer() {
        // just add this line
        MakePlay(btnRow, btnCol, btnText);
        return move;
    } 
    private void btn_click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int btnRow = Convert.ToInt32(btn.Tag) / 10;
        int btnCol = Convert.ToInt32(btn.Tag) % 10;
        btn.Text = game.ToggleNextLetter();
        MakePlay((btnRow, btnCol, btn.Text);
    }
    private void MakePlay(int btnRow, int btnCol, string btnText) {
        game.Matrix(btnRow, btnCol, btn.Text);
        btn.Enabled = false;
        //btn.Text = game.ToggleNextLetter();
  
        if (game.HasWinner())
        {
            foreach (var control in Controls)
            {
                try
                {
                    Button b = (Button)control;
                    b.Enabled = false;
                }
                catch { }
            }
            MessageBox.Show("The winner is " + btn.Text);
        }
    }
