    [TestMethod]
    public void GetYearsTest()
    {
        //_sut is the System Under Test,  in this case is an instance of your controller
        var years = await _sut.GetYears();
        //Any Assert that you want
    }
