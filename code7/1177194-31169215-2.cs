    private void VerifyArrayString(string theString)
    {
        var elements = theString.Split(new[] { ',' }, 
                                       StringSplitOptions.RemoveEmptyEntries);
        foreach (var element in elements.Where(el => !string.IsNullOrEmpty(el))
        {
            if (element == "SomeString")
            {
               // Do Something
            }
        }
    }
