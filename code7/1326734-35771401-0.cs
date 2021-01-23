    [Test]
    [Category(Helper.TEST_CATEGORY_SAVE_FOR_WEB)]
    public void SaveForWebTest ()
    {
        // arrange
        var slgdController = FakeSaveLoadGameDataController();
        TestDelegate myDelegate = () => {};
        // act
        try
        {
            slgdController.SaveForWeb();
            Assert.IsTrue(true) // Not Actually necessary as should still pass
        }
        catch
        {
            Assert.Fail("Expected no exception, but got: " + ex.Message);
        }
    }
