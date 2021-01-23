    public List<Suit> GetSuits()
    {
        var result = new List<Suit>();
        foreach (Stock stock in allStock)
        {
            var suit = stock as Suit;
            if (suit != null)
            {
                result.Add(suit);
            }
        }
        return result;
    }
