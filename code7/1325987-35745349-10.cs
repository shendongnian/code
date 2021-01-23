    var sqlDbType = SqlHelper.GetDbType<string>();
    // or:
    var sqlDbType = SqlHelper.GetDbType(typeof(DateTime?));
    // or:
    var sqlDbType = SqlHelper.GetDbType(property.PropertyType);
