    [Test]
    [Combinatorial]
    public void YourTest(
        [Values(null, "", "John")] string firstName, 
        [Values(null, "", "Doe")] string lastName)
    {
        var testObject = new SomeEntity {
            Id = 1, // this must be always 1 for this test
            FirstName = firstName,
            LastName = lastName
        };
    
        var result = someOtherObject.DoSomething(testObject);
    
        Assert.AreEqual("some expectation", result);
    }
