    string Name = methodBase.Name;            
    try
    {
    	// Specific TestCase Function
    	Assert.Fail("This is a fail test");
    }
    catch (SuccessException ex)
    {
    	// Test passed
    	GetResult(Name);
    }
    catch (AssertionException exception)
    {
    	// Test failed
    	GetResult(Name);
    }
    catch (Exception exception)
    {
    	// Test Inconclusive or Error occurs
    	GetResult(Name);
    }
