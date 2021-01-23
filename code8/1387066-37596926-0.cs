    public void JValueParsingTest()
    {
        var jsonString = @"{""Name"":""Rick"",""Company"":""West Wind"",
                            ""Entered"":""2012-03-16T00:03:33.245-10:00""}";
    
        dynamic json = JValue.Parse(jsonString);
    
        // values require casting
        string name = json.Name;
        string company = json.Company;
        DateTime entered = json.Entered;
    
        Assert.AreEqual(name, "Rick");
        Assert.AreEqual(company, "West Wind");            
    }
