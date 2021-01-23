    [Test]
    [InlineAutoData(1, 2)]
    [InlineAutoData(3, 4)]
    public void Whatever_Test_Name(int param1, int param2, TemplateOrder sut)
    {
        //Your test here
        Assert.That(sut, Is.Not.Null);
    }
