    Message msg = new Message();
    IMyDbContext fakeDbContext = NSubstitute.Substitute.For<IMyDbContext>();
    
    var messagesSet = NSubstitute.Substitute.For<DbSet<Message>>();
    fakeDbContext.Create<Message>().Returns(msg);
    fakeDbContext.Messages.Returns(messagesSet);
