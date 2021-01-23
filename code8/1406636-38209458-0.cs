    public int IndexOf(T item)
    {
        return this.FindIndex(x => item.Equals(x));
    }
    public int IndexOf(T item, int startIndex)
    {
        return this.FindIndex(startIndex, x => item.Equals(x));
    }
    public int IndexOf(T item, int startIndex,int count)
    {
        return this.FindIndex(startIndex, count, x => item.Equals(x));
    }
