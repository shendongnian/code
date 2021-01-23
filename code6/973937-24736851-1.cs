    var containerRepoMock = new Mock<IRepositoryAsync<Container>>();
    var queryFluentQueryMock = new Mock<IQueryFluent<Container>>();
    var queryFluentIncludeMock = new Mock<IQueryFluent<Container>>();
    Expression<Func<Container, bool>> query = null;
    containerRepoMock.Setup(p => p.Query(It.IsAny<Expression<Func<Container, bool>>>()))
                     .Callback<Expression<Func<Container, bool>>>(q => query = q)
                     .Returns(queryFluentQueryMock.Object);
    Expression<Func<Container, object>> include = null;
    queryFluentQueryMock.Setup(p => p.Include(It.IsAny<Expression<Func<Container, object>>>()))
                        .Callback<Expression<Func<Container, object>>>(i => include = i)
                        .Returns(queryFluentIncludeMock.Object);
    queryFluentIncludeMock.Setup(p => p.Select())
                     .Returns(containers.AsQueryable().Where(query).Include(include));
