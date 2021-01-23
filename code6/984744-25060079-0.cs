    private bool EndWith(string input, string end)
    {
        string pattern = @"" + end + @"$";
        Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);
        return rx.Match(input).Success;
    }
    
    private string bindSuffix(string suffix)
    {
        string result = null;
    
        foreach (var key in Request.QueryString.AllKeys)
        {
            if (EndWith(key, suffix))
            {
                result = Request.QueryString[key];
            }
        }
    
        return result;
    }
    //Then use it like that
    public JsonResult ValidName()
    {
        string name = bindSuffix("user.name");
        ...
    }
