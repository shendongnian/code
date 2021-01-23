    public string odd1
    { 
        get { return (Odds.Count >= 2) ? Odds[0] : "error"; }
        set { if (Odds.Count >= 2) Odds[0] = value; }
    }
    public string oddX
    { 
        get { return (Odds.Count >= 2) ? Odds[1] : "error"; }
        set { if (Odds.Count >= 2) Odds[1] = value; }
    }
    public string odd2
    { 
        get { return (Odds.Count >= 2) ? Odds[2] : "error"; }
        set { if (Odds.Count >= 2) Odds[2] = value; }
    }
