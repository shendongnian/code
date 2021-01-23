    [TestMethod]
    public void CanSave_CurrentUserHasNoPermission_LogsWarning()
    {
        // Arrange
        var logger = new FakeLogger();
        var noPermission = new FakeSecurity { CurrentUserHasPermission = false };
        MaintainColorsViewModel viewModel = CreateViewModel(logger, noPermission);
        // Act
        bool temp = viewModel.CanSave;
        // Assert
        Assert.IsTrue(logger.Entries.Any());
    }
    
