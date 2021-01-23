    var mock = new Mock<IFoo>();
    var parameterExpression = Expression.Parameter(typeof(IFoo));
    foreach (var property in typeof(IFoo)
      .GetProperties().Where(x => x.PropertyType == typeof(int))
      )
    {
      var lambdaExpression = Expression.Lambda<Func<IFoo, int>>(
        Expression.Property(parameterExpression, property),
        parameterExpression);
      mock.Setup(lambdaExpression).Returns(12);
    }
