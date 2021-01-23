    public void CanSave_CurrentUserHasNoPermission_ReturnsFalse() {
        // Arrange
        var noPermission = new FakeSecurity { CurrentUserHasPermission = false };
        var viewModel = new MaintainColorsViewModel(noPermission);
        // Act
        bool actualResult = viewModel.CanSave;
        // Assert
        Assert.IsFalse(actualResult);
    }
    
    public void CanSave_CurrentUserHasPermission_ReturnsTrue() {
        // Arrange
        var hasPermission = new FakeSecurity { CurrentUserHasPermission = true };
        var viewModel = new MaintainColorsViewModel(hasPermission);
        // Act
        bool actualResult = viewModel.CanSave;
        // Assert
        Assert.IsTrue(actualResult);
    }
    
    public void CanSave_Always_QueriesTheSecurityForTheSaveColorsPermission() {
        // Arrange
        var security = new FakeSecurity();
        var viewModel = new MaintainColorsViewModel(security);
        // Act
        bool temp = viewModel.CanSave;
        // Assert
        Assert.IsTrue(security.RequestedPermissions.Contains("Save Colors"));
    }    
