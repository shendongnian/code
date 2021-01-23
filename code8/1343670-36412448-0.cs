    /// <summary>
    /// Closes the test browser and ends test playback
    /// </summary>
    [TestCleanup]//The decorator is what makes this a method a test cleanup
    public void CleanTest()
    {        
        if (Playback.IsInitialized) //This is the important part.
        {
            Playback.Cleanup();
        }
        if (browserWindow.Exists)
        {
            browserWindow.Close();
        }
    }
