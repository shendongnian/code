    [TestMethod]
    public void WriteToConsoleTest()
    {
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            ConsoleOutput.Main();
            Assert.AreEqual("Hello World!", sw.toString());
        }
    }
