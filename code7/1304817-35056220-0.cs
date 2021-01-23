    [TestMethod]
    public void Version_Get_All()
    {
         //Arrange
        _versionServiceMock.Setup(x => x.Queryable()).Returns(listVersion);
         //Act
        var result = (( objController.Index() as ViewResult).Model) as List<Model.Models.Version>;
    }
