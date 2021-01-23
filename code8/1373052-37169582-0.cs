    [Theory]
    [InlineAutoMoqData(3,4)]
    [InlineAutoMoqData(33,44)]
    [InlineAutoMoqData(13,14)]
    public void SomeUnitTest(int DataFrom, int OtherData, [Frozen]Mock<ISomeInterface> theInterface, MySut sut)
    {
         // actual test omitted
    }
