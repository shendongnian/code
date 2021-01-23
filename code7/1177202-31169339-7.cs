    string string1 = "item1, item2";
    string string2 = "item01, item02, item03";
    private void VerifyArrayString(string theString)
    {
        var elements = theString.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
        for(int i=0; i<elements.Length; i++)
        {
           if(elements[i] != null)
           {
               //do something
           }
        }
    }
