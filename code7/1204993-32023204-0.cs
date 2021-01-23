    var fakeProvider = MockRepository.GenerateStub<IProvideDataAccess<Entity>>();
    fakeProvider.Select(o => o.Id =="asdfg");
    fakeProvider.AssertWasCalled(access => access.Select(Arg<Func<Entity, bool>>
                .Matches(func => func(new Entity()
                {
                    Id = "asdfg"
                }))));
