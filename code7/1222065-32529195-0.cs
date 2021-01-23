    public bool CheckIfIsTrueType(string font)
    {
        try
        {
            var ff = new FontFamily(font)
        }
        catch(ArgumentException ae)
        {
            // this is also thrown if a font is not found
            if(ae.Message.Contains("TrueType"))
        		return false;        
            throw;
        }
        return true;
    }
