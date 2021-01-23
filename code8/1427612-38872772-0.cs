    Public ImmutableDeck PutCardOnBottom (Card c)
    {
        if (!this.next.IsEmpty)
            this.next.PutCardOnBottom(c);
        else
            this.next = new ImmutableDeck(c, ImmutableDeck.Empty);
        return this;
    }
