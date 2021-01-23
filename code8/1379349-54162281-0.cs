    const string destination = "Destination.txt";
    const string source = "MyData.txt";
    [DeploymentItem(source)]
    [TestMethod]
    public void MyMethod() 
    {
        // …
        File.Copy(source, destination, true);
        // …
    }
    [TestCleanup]
    public void Cleanup()
    {
        // Clean up the destination so that subsequent tests using
        // the same deploy don’t collide.
        File.Delete(destination);
    }
