    public int CompareTo(User b)
    {
        DateTime x = DateTime.ParseExact(this.placed,...);
        DateTime y = DateTime.ParseExact(b.placed,...);
        return x.CompareTo(y);
    }
