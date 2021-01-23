    var sourceProperties = typeof(DbModel1.Product).GetProperties();
    var destinationProperties = typeof(DbModel2.Product).GetProperties();
    var commonProperties = sourceProperties
        .Join(destinationProperties,
            propInfo => propInfo.Name,
            propInfo => propInfo.Name,
            (source, dest) => new KeyValuePair<PropertyInfo, PropertyInfo>(source, destination))
        .ToArray();
