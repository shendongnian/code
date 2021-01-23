    private void AssertException<T>(Action method)
        where T : Exception
    {
        try
        {
            method();
            Assert.Fail();
        }
        catch (T e)
        {
            Assert.IsTrue(true);
        }
    }
