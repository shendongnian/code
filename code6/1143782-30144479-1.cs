    public virtual bool concatOnly()
    {
        int tmp = 0;
        string w;
        foreach (w in words)
        {
            tmp += w.Length;
        }
        return (tmp <= w.Length);
     }
