    var roles = new Role[]
    {
       new Role
       {
          ...
       },
       ...
    };
    var mockRepository = new Mock<IRoleRepository>.Setup(r => r.QueryRoles()).Returns(roles.AsQueryable());
