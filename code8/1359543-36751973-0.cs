    public Mock<IRepository<Claims>> MockClaimsRepository()
    {
        var repository = new Mock<IRepository<Claims>>();
        var claims = new List<Claims>(); // Add variables to be used in the setups
        repository.Setup(x => x.GetAll()).Returns(claims.AsQueryable());
        repository.Setup(x => x.GetById(It.IsAny<int>())).Returns<int>(id => claims.Find(c => c.Id == id));
        repository.Setup(x => x.Add(It.IsAny<Claims>())).Callback<Claims>(c => claims.Add(c));
        repository.Setup(x => x.Delete(It.IsAny<Claims>())).Callback<Claims>(c => claims.Remove(c));
        ...
        return repository;
    }
