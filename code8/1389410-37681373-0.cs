    IQueryable<NodeAttributeTitle> data = new List<NodeAttributeTitle>
    {
        new NodeAttributeTitle() {Id = 1, Title = "t1"},
        new NodeAttributeTitle() {Id = 2, Title = "t2"},
    }.AsQueryable();
    var mockSet = new Mock<IDbSet<NodeAttributeTitle>>();
    mockSet .Setup(m => m.Provider).Returns(data.Provider);
    mockSet .Setup(m => m.Expression).Returns(data.Expression);
    mockSet .Setup(m => m.ElementType).Returns(data.ElementType);
    mockSet .Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
