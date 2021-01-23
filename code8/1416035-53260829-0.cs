    Mock<IQueueItemRepository> queueMock = new Mock<IQueueItemRepository>();
    queueMock
        .Setup(x => x.GetFirstNotIn(It.IsAny<Collection<Guid>>()))
        .Returns(new QueueItem());
    
