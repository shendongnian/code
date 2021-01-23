    [TestMethod]
    public void Test_Should_Simulate_Command_Line_Argument() {
        // Arrange
        string[] expectedArgs = new[] { "Hello", "World", "Fake", "Args" };
        var mockedCLI = new Mock<ICommandLineInterface>();
        mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);
        var target = mockedCLI.Object;
        // Act
        var args = target.GetCommandLineArgs();
        // Assert
        args.Should().NotBeNull();
        args.Should().ContainInOrder(expectedArgs);
    }
