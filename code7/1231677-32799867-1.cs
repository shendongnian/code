    private F1(ImmutableList<int> baseList, int pos, int value)
    {
        var tempList = baseList.ToList(); // create mutable list.
        tempList[pos] = value; // modify list.
        this.k2 = new ImmutableList<int>(tempList); // immutablize!
    }
    public F1 GetModifiedCopy(int pos, int value)
    {
        return new F1(this.k2, pos, value);
    }
