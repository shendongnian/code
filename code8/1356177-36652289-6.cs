    [TestMethod]
    public async Task Registry_Should_Return_DeviceKey() {
        //Arrange
        var expectedPrimaryKey = Guid.NewGuid().ToString();
        var deviceId = Guid.NewGuid().ToString();
        var fakeDevice = new Device(deviceId) {
            Authentication = new AuthenticationMechanism {
                SymmetricKey = new SymmetricKey {
                     PrimaryKey = expectedPrimaryKey
                }
            }
        };
        var registryManagerMock = new Mock<IRegistryManager>();
        registryManagerMock.Setup(m => m.GetDeviceAsync(deviceId))
            .ReturnsAsync(fakeDevice);
        var registry = new Registry(registryManagerMock.Object);
        //Act                
        var deviceKey = await registry.GetDeviceKey(deviceId);
        //Assert
        deviceKey.Should().BeEquivalentTo(expectedPrimaryKey);
    }
