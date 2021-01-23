    Indexer<int, int> firstColumn = new Indexer<int, int>(
        i => X[i, 0],
        (i, v) => X[i, 0] = v);
    public Indexer<int, int> FirstColumn
    {
        get { return firstColumn; }
    }
    Indexer<int, int> secondColumn = new Indexer<int, int>(
        i => X[i, 1],
        (i, v) => X[i, 1] = v);
    public Indexer<int, int> SecondColumn
    {
        get { return secondColumn; }
    }
