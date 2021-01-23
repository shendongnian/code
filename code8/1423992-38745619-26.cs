    pubic void ConfirmImNotSleeping_WhenCalled_CallsAdd()
    {
        var cacheStub = new Mock<ICache>();
        var notifierStub = new Mock<INotifier>();
        var service = new SleepingMembersService(cache.Object, notifier.Object);
        var userStub = new Mock<IUser>();
        service.ConfirmNotSleeping(user.Object);
        cacheStub.Vertify(x => x.Add(It.IsAny<string>(), It.IsAny<TimeStamp>(), true));
    }
