    mockQueryOver.Setup(x => x.JoinAlias(
								   It.IsAny<Expression<Func<Company, object>>>(), 
                                   It.IsAny<Expression<Func<object>>>(),
                                   JoinType.LeftOuterJoin))
                 .Returns(mockQueryOver.Object);
