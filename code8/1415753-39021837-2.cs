        [Theory]
        [MemberData(nameof(StockIds))]
        public async Task GivenSomeData_DoFooAsync_AddsDataToTheQueue(string[] stockIds)
        {
            // Arrange.
            var cloudQueue = Mock.Of<ICloudQueueWrapper>();
            var cloudQueueClient = Mock.Of<ICloudQueueClientWrapper>();
            Mock.Get(cloudQueueClient).Setup(x => x.GetQueueReference(It.IsAny<string>()))
                .Returns(cloudQueue);
            var someService = new SomeService(cloudQueueClient);
            // Act.
            await someService.DoFooAsync(Session);
            // Assert.
            // Did we end up getting a reference to the queue?
            Mock.Get(cloudQueueClient).Verify(x => x.GetQueueReference(It.IsAny<string>()), Times.Once);
            // Did we end up adding something to the queue?
            Mock.Get(cloudQueue).Verify(x => x.AddMessageAsync(It.IsAny<CloudQueueMessage>()), Times.Exactly(stockids.Length));
        }
