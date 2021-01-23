    public IEnumerable<ChessField> Method(ChessField c)
    {
       return Enumerable.Range(0, 3)
                        .Select(i => new ChessField() {b1 = c.b1, b2 = c.b2, i1 = i});
    }
