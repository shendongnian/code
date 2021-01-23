    private void AssertThrows<T>(Action action) where T: Exception
    {
        try
        {
            action();
        }
        catch (T)
        {
            Assert.Pass();
        }
        Assert.Fail();
    }
