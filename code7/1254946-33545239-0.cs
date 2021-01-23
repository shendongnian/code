    [Fact]
    public void TestComplexClassEquality()
    {
        // Arrange
        var value = new ComplexMasterObject
        {
            Child1 = new ChildFirst
            {
                SomeStringProp1 = "1",
                SomeIntProp1    =  2
            },
            Child2 = new ChildSecond
            {
                SomeStringProp1 = "3",
                SomeIntProp1    =  4
            },
            SimpleProp          = "5"
        };
        var other = new ComplexMasterObject
        {
            Child1 = new ChildFirst
            {
                SomeStringProp1 = "1",
                SomeIntProp1    =  2
            },
            Child2 = new ChildSecond
            {
                SomeStringProp1 = "3",
                SomeIntProp1    =  4
            },
            SimpleProp          = "5"
        };
        var sut =
            new SemanticComparer<ComplexMasterObject>(
                new MemberComparer(
                    new AnyObjectComparer()),
                new MemberComparer(
                    new ChildFirstComparer()),
                new MemberComparer(
                    new ChildSecondComparer()));
            
        // Act
        var actual = sut.Equals(value, other);
            
        // Assert
        Assert.True(actual);
    }
