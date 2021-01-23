    public object TheMethod(...)
    {
        var theJson = new 
        {
            type = "Redirect",
            data = new 
            {
               url = "/submitted",
               form = new 
               {
                   firstName = "Bob",
                   lastName = "Smith"
               }            
            }
        };
        return theJson;
    }
