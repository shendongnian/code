    public virtual bool concatOnly()
    {
        int tmp = 0;
        foreach (string w in words)
        {
            tmp += w.Length;
        }
        return (tmp <= word.Length);
     }
