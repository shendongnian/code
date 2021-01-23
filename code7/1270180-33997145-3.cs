    public void Test()
    {
        One one = new One {S2 = "OneTwoThreeFour"};
        Two two = Mapper.Map<One, Two>(one);
        Assert.AreEqual(1, two.List1.Count);
        Assert.AreEqual("OneTwoThreeFour", two.List1.Single());
    }
