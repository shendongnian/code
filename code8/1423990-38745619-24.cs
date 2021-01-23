    pubic void ConfirmImNotSleeping_WhenCalled_CallsAdd()
    {
        var cache = new StubCache<bool>();
        var notifier = new StubNotifier();
        var service = new SleepingMembersService(cache, notifier);
        var user = new StubUser(1, "John Doe");
        service.ConfirmNotSleeping(user);
        Assert.IsTrue(cache.AddValue);
    }
