    private void btnRoll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < dice.Length; i++)
            dice[i] = rand.Next(1, 7);
        Array.Sort(dice);
        lblDie1.Image = diceImages[dice[0]];
        lblDie2.Image = diceImages[dice[1]];
        lblDie3.Image = diceImages[dice[2]];
        lblDie4.Image = diceImages[dice[3]];
        lblDie5.Image = diceImages[dice[4]];
    }
