    [Test]
    public void GetDeviceSettings_is_called()
    {
        //Arrange
        var mockDeviceInteractions = new Mock<IDeviceInteractions>();
        var deviceSettings = new Mock<IDeviceSettings>();
        mockDeviceInteractions.Setup(x => x.GetDeviceSettings(@"123123", "dfgdfg"))
            .Returns(deviceSettings.Object)
            .Verifiable();
        //Act
        var actual = mockDeviceInteractions.Object.GetDeviceSettingsForSerialNumber(@"123123");
        //Assert
        Assert.Equal(deviceSettings.Object, actual);
        mockDeviceInteractions.Verify();
    }
