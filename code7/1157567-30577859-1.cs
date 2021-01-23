    [TestMethod]
    public void WriteToConsoleTest()
    {
        // setup test - redirect Console.Out
        var sw = new StringWriter();    
        Console.SetOut(sw);
    
        // exercise system under test
        ConsoleOutput.Main();
    
        // verify
        Assert.AreEqual("Hello World!\r\n", sw.ToString());
    }
