    Collection<PSObject> results = null;
    try
    {
        results = pipeline.Invoke();
        // results returned from PowerShell can be accessed here but may not
        // necessarily be valid since a 'Continue' error could have occurred
        // which would not generate an exception
    }
    catch (RuntimeException e)
    {
        Debug.WriteLine("Error: " + e.Message);
    }
