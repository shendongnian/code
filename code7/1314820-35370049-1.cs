    private string DateDiff(Object thisObj)
    {
        String result = "";
        try
        {
            DateTime thisDT = (DateTime)thisObj;
            TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - thisDT.Ticks);
            // Now just format the TimeSpan how you want into result
            result = ts.Days.ToString() + " Days";
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
            //Do Nothing    
        }
        return result;
    }
