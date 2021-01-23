    [TestMethod]
    public void SetupABCDQuestTest()
    {
        var questA = new Quest();
        Assert.IsTrue(questA.CanStart());
        var questB = new Quest();
        Assert.IsTrue(questB.CanStart());
        var questC = new Quest();
        questC.Add(questB);
        Assert.IsFalse(questC.CanStart());
        questB.Complete = true;
        Assert.IsTrue(questC.CanStart());
        var questD = new Quest();
        questD.Add(questA);
        questD.Add(questC);
        Assert.IsFalse(questD.CanStart());
        questA.Complete = true;
        questC.Complete = true;
        Assert.IsTrue(questD.CanStart());
    }
