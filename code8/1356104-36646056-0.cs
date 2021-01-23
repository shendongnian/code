    var propertyType = propertyInfo.PropertyType;
    var openGenericMethod = typeof (MockRepository).GetMethods()
            .Single(x => x.Name == "GenerateStub" && x.IsGenericMethod);
    var closedGenericMethod = openGenericMethod.MakeGenericMethod(propertyType);
    var stub = closedGenericMethod.Invoke(null,  new object[] { new object[0] });
