    [Test]
    [Category(Helper.TEST_CATEGORY_SAVE_FOR_WEB)]
    public void SaveForWebTest ()
    {
        // arrange
        var slgdController = FakeSaveLoadGameDataController();
        Assert.DoesNotThrow(() => slgdController.SaveForWeb());
    }
