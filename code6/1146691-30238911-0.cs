    [TestMethod]
    public void GetInfo_ClonesAllProperties()
    {
        // arrange
        var myClass = new myClass() { FirstName = "John", SurName = "Smith" };
        // act
        var clone = myClass.GetInfo();
        // assert
        Assert.AreEqual(clone.FirstName,"John");
        Assert.AreEqual(clone.SurName,"Smith");
    }
