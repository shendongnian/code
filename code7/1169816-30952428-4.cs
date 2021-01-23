        public void DoSomething_WhenCalled_AddNLogConfigurationTypeTagretGetsCalled()
        {
            // Arrange
            bool addNLogConfigurationTypeTagretWasCalled = false;
            Mock<ITargetBuilder> targetBuilderMock = new Mock<ITargetBuilder>();
            targetBuilderMock.Setup(b => b.AddNLogConfigurationTypeTagret())
                .Callback(() => addNLogConfigurationTypeTagretWasCalled = true);
            ConsoleTargetBuilderClient client = new ConsoleTargetBuilderClient(targetBuilderMock.Object);
    
            // Act
            client.DoSomething();
    
            // Assert
            Assert.IsTrue(addNLogConfigurationTypeTagretWasCalled);
        }
