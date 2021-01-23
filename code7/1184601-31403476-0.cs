        [SetUp]
        public void TestInit()
        {
            Mock<ITimeConsume> moc = GetMockObj(...);
            builder.RegisterInstance(moc).As<ITimeConsume>();
            ...
            ...
            _target = new ServiceClass(builder.Build());
        }
