    public static string YourMethod()
    {  
        var bar = "records: [{0: \"<a name=\"3096\" href=\"xxx\">3096</a>\",1: \"02/03/2016\",},{0: \"<a name=\"3097\" href=\"yyy\">3097</a>\",1: \"02/03/2016\",}]";
        var result = StripHTML(bar);
        return result;
    }
    
    public static string StripHTML(string input)
    {
       return Regex.Replace(input, "<.*?>", String.Empty);
    }
