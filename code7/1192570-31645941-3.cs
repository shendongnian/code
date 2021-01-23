    var addressProperty = typeof (User).GetProperty("Address");
    var cityProperty = typeof(Address).GetProperty("City");
    var userParameter = Expression.Parameter(typeof (User), "user");
    var getCityFromUserParameter = Expression.Property(Expression.Property(userParameter, addressProperty), cityProperty);
    var lambdaGetCity = Expression.Lambda<Func<User, string>>(getCityFromUserParameter, userParameter);
