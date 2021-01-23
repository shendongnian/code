    [TestMethod()]
    public void Test_this_method()
    {
        IFileWrap fileWrapRepository = MockRepository.GenerateMock<IFileWrap>();
        fileWrapRepository.expect(x => x.ReadAllLines("abc.txt").Return(new string[] {"Line 1", 
                                                                          "Line 2", "Line 3"});
    
        MethodThatReadsLines(fileWrapRepository.Object);
    }
