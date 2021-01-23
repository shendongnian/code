    List<int> Deck = new List<int> { 0, 1, 2, 3};//global
    private void button1_Click(object sender, EventArgs e)
    {
       Random R = new Random();
       int Card = R.Next(Deck.Count);
       Deck.Remove(Card);
    }
