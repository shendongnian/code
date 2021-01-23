    public bool TryGetPersonCode(ref int value)
    {
        try
        {
            //This is setted on login
            value = (int)Session["PersonCode"];
            return true; // Success
        }
        catch (Exception e)
        {
            Log(e);
            return false; // Failed
        }
    }
