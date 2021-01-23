    [Test]
    public void ShouldPassAllTests()
    {
        var result1 = Step1();
        var result2 = Step2(result1);
        var result3 = Step3(result2);
        Step4(result3);
    }
    private void Step1/2/3/4()
    {
        // Arrange Something
        // Do Something
        // Assert Something
    }
