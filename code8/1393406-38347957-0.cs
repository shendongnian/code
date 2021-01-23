    [TestMethod, Isolated]
    public void ShouldValidateReadingOfTheFile()
    {
        var fileContents = 
    @"1
    100";
        StreamReader reader = new StreamReader(
            new MemoryStream(Encoding.ASCII.GetBytes(fileContents)));
    
        Isolate.WhenCalled(() => File.OpenText("fake")).WillReturn(reader);
    
        var result = Class1.ReadIntegers("fake").ToArray();
    
        var resList = new int[] {1, 100};
        CollectionAssert.AreEquivalent(resList, result);
    }
