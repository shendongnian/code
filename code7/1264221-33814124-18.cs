    [TestMethod]
    public void CanSave_CurrentUserHasNoPermission_ReturnsFalse()
    {
        // Arrange
        var noPermission = new FakeSecurity { CurrentUserHasPermission = false };
        MaintainColorsViewModel viewModel = CreateViewModel(noPermission);
        // Act
        bool actualResult = viewModel.CanSave;
        // Assert
        Assert.IsFalse(actualResult);
    }
