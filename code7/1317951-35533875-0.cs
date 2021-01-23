    [TestMethod, Isolated]
    public void CountPrivateCalls()
    {
        int counter = 0;
        var fileChecker = new FileChecker();
        var testFile = new StreamReader("test.txt");
    
        Isolate.NonPublic.WhenCalled(fileChecker, "putToExceptions").DoInstead(context =>
        {
            counter++;
            context.WillCallOriginal();
        });
    
        fileChecker.FileManipulator(testFile);
    
        Assert.AreEqual(3, counter);
    }
