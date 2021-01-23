    public string PrintCrate()
    {
        string rv = "";
        foreach (var soda in sodaCans)
        {
            if (soda != null)
            {
                rv += "\n" + soda;                    
            }
        }
    
        return rv;
    }
