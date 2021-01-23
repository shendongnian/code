    [TestMethod]
    public void LevelsVMConstructorTest()
    {
        using (ShimsContext.Create())
        {
            List<Level> levels = new List<Level>();
            levels.Add(new Level() { Id = 1, LevelId = 1, Name = "abc", IsRoot = true });
            var levelsIQ = levels.AsQueryable();
            var fakeDataServiceQuery = new System.Data.Services.Client.Fakes.ShimDataServiceQuery<Level>();
            fakeDataServiceQuery.ProviderGet = () => levelsIQ.Provider;
            fakeDataServiceQuery.ExpressionGet = () => levelsIQ.Expression;
            fakeDataServiceQuery.ElementTypeGet = () => levelsIQ.ElementType;
            fakeDataServiceQuery.GetEnumerator = levelsIQ.GetEnumerator;
            var defaultContainerMock = new Mock<DefaultContainer>();
            defaultContainerMock.Setup(m => m.Levels).Returns(fakeDataServiceQuery);
            LevelViewer lv = new LevelViewer(odataContainerMock.Object);
            Assert.IsTrue(lv.GetRootLevels().Any());
       }
    }
