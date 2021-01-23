    ActivitiesMock
        .Setup(x => x.Where(It.IsAny<Expression<Func<Activity, bool>>>()))
        .Returns((Expression<Func<Activity, bool>> x) =>
        {
            actualPredicate = x;
            return queryMock.Object;
        });
