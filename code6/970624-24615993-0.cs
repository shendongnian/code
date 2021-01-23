    var internals = new Mock<DbSet<InternalTransaction>>();
    var mockDC = new Mock<IDataContext>();
    
    mockDC.Setup(q => q.InternalTransactions).Returns(internals.Object);
    internals.Setup(q => q.Create()).Returns(new InternalTransaction());
    
    var transaction = new ExternalTransaction { [set criteria for Condition A] };
    
    SomeBusinessObject.AddTriggeredInternalTransactions(mockDC.Object, transaction);
    
    // verify the Add method was executed exactly once
    internals.Verify(e => e.Add(It.IsAny<InternalTransaction>()), Times.Once());
