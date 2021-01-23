    public static bool Alive(this AutomationElement ae)
    {
        try
        {
            var t = ae.Current.Name;
            return true;
        }
        catch(ElementNotAvailableException)
        {
            return false;
        }
    }
