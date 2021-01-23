        [TestMethod]
        public void Shared_factory_instance_resolves_multiple_transformers()
        {
            // Arrange
            var factory = new MessageTransformFactory();
            IMessageTransformer<AMessage> aTransformer = factory.CreateTransformer<AMessage>(DeviceTypeEnum.Foo);
            IMessageTransformer<BMessage> bTransformer = factory.CreateTransformer<BMessage>(DeviceTypeEnum.Bar);
            // Act
            AMessage aMessage = aTransformer.Transform(new IncomingFooMessage());
            BMessage bMessage = bTransformer.Transform(new IncomingBarMessage());
            // Assert
            Assert.IsNotNull(aMessage, "Transformer failed to convert the IncomingMessage");
            Assert.IsNotNull(bMessage, "Transformer failed to convert the IncomingMessage");
        }
