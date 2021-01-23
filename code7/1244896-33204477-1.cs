    public bool Equals(DeckOfCards other)
    {
        for (int i = 0; i < CARDS; i++)
        {
            if (!cards[i].Equals(other[i]))
            {
                return false;
            }
        }
    
        return true;
    }
