    var roles = new Role[]
    {
       new Role
       {
          ...
       },
       ...
    };
    var mockRepository = new Mock<IRoleRepository>();
    mockRepository.Setup(r => r.QueryRoles()).Returns(roles.AsQueryable());
