    public void SomeMethod()
    {
        try
        {
            DoSomethingThatExcepts();
        }
        catch (Exception e)
        {
            //You are actually catching the defined Exception, not System.Exception
        }
    }
