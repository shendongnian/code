    public int ModeIdx
    {
        get 
        {  
            var result = Session["modIdx"] as int?;
            return result ?? 0; //Default to 0 if we can't cast to int, or the value was never set.
        }
        set { Session["modIdx"] = value; }
    }
