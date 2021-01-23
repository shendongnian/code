    private void buttonDeal_Click(object sender, EventArgs e)
    {
        Card card = deck.DealCard();
        deck.DealCard(); // error here. Duplicated line
        labelOutput.Text = card.ToString();
    }
