    private void btn1_Click(object sender, EventArgs e)
    {
        if (PlayerTurn == 1)
        {
            OneDown = OneDown + 5;
            OneAcross = OneAcross + 5;
            SlashOne = SlashOne + 5;
            btn1.Text = "X";
            btn1.Enabled = false;
            PlayerTurn = PlayerTurn - 1;
            lblTurn.Text = "O";
            if (SlashOne == 15 || OneAcross == 15 || OneDown == 15)
            {
                MessageBox.Show("Player 1 Wins!");
            }
        }
        else if (PlayerTurn == 0)
        {
            OneDown = OneDown + 3;
            OneAcross = OneAcross + 3;
            SlashOne = SlashOne + 3;
            btn1.Text = "O";
            btn1.Enabled = false;
            PlayerTurn = PlayerTurn + 1;
            lblTurn.Text = "X";
            lblTest.Text = OneDown.ToString();
            if (SlashOne == 9 || OneAcross == 9 || OneDown == 9)
            {
                MessageBox.Show("Player 2 Wins!");
            }
        }
