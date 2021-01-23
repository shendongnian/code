    string string1 = "item1, item2";
    string string2 = "item01, item02, item03";
    private void VerifyArrayString(string theString)
    {
        var elements = theString.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
        for(int i=0; i<elements.Length; i +=1)
        {
           if(elements.Length > 0 && elements[0] != null)
           {
               //do something
           }
           if(elements.Length > 1 && elements[1] != null)
           {
               //do something
           }
                   // and so and so with the next items....
        }
    }
