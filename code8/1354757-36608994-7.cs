    public void Build_ReturnsSpecificException_FileNamePassedIn<TException>(string fileName,
        ProcessFactory sut)
        where TException : Exception
    {
        Assert.Throws<TException>(() => sut.Build(fileName));
    }
    [Theory]
    [InlineAutoMoqData("bork")]
    public void Build_ReturnsSpecificException_FileNamePassedIn(string fileName,
        ProcessFactory sut)
    {
        Build_ReturnsSpecificException_FileNamePassedIn<FileTypeNotRecognizedException>(fileName, sut);
    }
    [Theory]
    [InlineAutoMoqData("borg")]
    public void Build_ReturnsAnotherException_FileNamePassedIn(string fileName,
        ProcessFactory sut)
    {
        Build_ReturnsSpecificException_FileNamePassedIn<Exception>(fileName, sut);
    }
