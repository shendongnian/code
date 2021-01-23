    public static IEnumerable<object[]> TestCases = 
    new TheoryData<Animal>{ new Bird { Eyes = 2 } };
    [Theory]
    [MemberData(nameof(TestCases))]
    public void TestEyes(Animal email)
    {
    //Arrange & Act & Assert
    }
;)
