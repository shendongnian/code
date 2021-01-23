    public void Shuffle()
    {
        Random r = new Random();
        int count = deck.Count();
        for (int i = 0; i < count; i++)
        {
            int rnd = (int)(r.Next(count--));
            deck.AddLast(deck.Delete(rnd));
        }
    }
