    public void DoSomething()
    {
        string pattern = TextBox1.Text;
    
        if(IsRegexPatternValid(pattern))
        {
            Regex regX = new Regex(pattern);
        }
        else
        {
            // handle invalid patterns here
            return;
        }
    }
    
    public static bool IsRegexPatternValid(String pattern)
    {
        try
        {
            new Regex(pattern);
            return true;
        }
        catch { }
        return false;
    }
