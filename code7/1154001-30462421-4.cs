    public List<ChessField> Method(ChessField c)
    {
        var result = new List<ChessField>();
        for (int i = 0;i<3;i++)
        {
           result.Add(new ChessField() {b1 = c.b1, b2 = c.b2, i1 = i});
        }
        return result;
    }
