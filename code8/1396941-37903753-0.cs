    Button btn;
     private void btnPick_Click(object sender, EventArgs e) //My method with 25 references (buttons)
     {
        for (int i = 5; i > 0; i--)
        {
            if (lblPicks.Text == "Picks Left: " + i)
            {
                picksLeft = i - 1;
            }
        }
        lblPicks.Text = "Picks Left: " + picksLeft.ToString();
        btn = sender as Button;
        btn.Enabled = false;
        multiplier = btn.Tag;
        value -= value * Convert.ToDouble(multiplier);
    }
