    string string1 = "item1, item2";
    string string2 = "item01, item02, item03";
    private void VerifyArrayString(string theString)
    {
        var elements = theString.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
        if (elements.Length >= (minimumNumber))
        {
            for (int i = 0; i < elements.Length; i += 3)
            {
                if (elements[0] != null)
                {
                    //do something
                }
                if (elements[1] != null)
                {
                    //do something
                }
                // and so and so with the next items....
            }
        }
    }
