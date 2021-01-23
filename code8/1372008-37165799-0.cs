    _clientRepositoryMock
        .Setup(m => m.GetAll(It.IsAny<IRelationPredicateBucket>(), 
                It.IsAny<int>(), It.IsAny<ISortExpression>(),
                It.IsAny<IPrefetchPath2>(), It.IsAny<IDataAccessAdapter>()))
        .Returns(_randomClients);
