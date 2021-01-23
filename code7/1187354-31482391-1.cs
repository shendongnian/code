    [TestMethod]
    public void GroupeRepere_HasExceptionFiltersAttribute()
     {
        var attribute = typeof (UnitTest2).GetMethod("GroupeRepere").GetCustomAttributes(true);
        foreach (var att in attribute)
        {
            if(att.GetType() is typeof(ExceptionFilters))
            {
                return;
            }
        }
        Assert.Fail();
    }
