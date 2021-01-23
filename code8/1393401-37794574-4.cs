    [Test]
    public void ShouldValidateReadingOfTheFile()
    {
        string stream = new MemoryStream();
        using (var sw = StreamWiter(stream))
        {
            sw.WriteLine(1);
            sw.WriteLine(100);
        }
        var expected = new List<int>() { 1, 100 };
        var actual = TestProject.Merge.ReadIntegersFromFile(path);
        Assert.IsTrue(expected.SequenceEqual(actual));
    }
