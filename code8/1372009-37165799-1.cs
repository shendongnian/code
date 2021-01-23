    _clientRepositoryMock
        .Setup(m => m.GetAll(It.IsAny<IRelationPredicateBucket>(), 
                It.IsAny<int>(), It.IsAny<ISortExpression>(),
                It.IsAny<IPrefetchPath2>(), It.IsAny<IDataAccessAdapter>()))
        .Returns(
            (IRelationPredicateBucket bucket) => _randomClients.Where(x => x.Name.Equals(bucket)));
