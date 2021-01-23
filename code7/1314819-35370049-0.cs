    private string DateDiff(Object thisObj)
    {
        DateTime dt = DateTime.Now;
        String result = "";
        try
        {
            DateTime thisDT = (DateTime)thisObj;
            TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - thisDT.Ticks);
            // Now just format the TimeSpan how you want into result
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
            //Do Nothing    
        }
        return result;
    }
