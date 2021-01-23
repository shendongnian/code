    [SetUp]
    public void Setup()
    {
        Mapper.CreateMap<PagedListResult<UserEntity>, PagedListResult<UserDto>>();
    }
    [Test]
    public void Q33128288()
    {
        PagedListResult<UserEntity> result = new PagedListResult<UserEntity>
        {
            Records = new List<UserEntity> {new UserEntity {Id = 7}},
            RecordCount = 1
        };
        var pagedListOfDtos = Mapper.Map<PagedListResult<UserDto>>(result);
        Assert.AreEqual(1, pagedListOfDtos.RecordCount);
        Assert.AreEqual(1, pagedListOfDtos.Records.Count());
        Assert.AreEqual(7, pagedListOfDtos.Records.Single().Id);
    }
