    public override object this[string propertyName]
    {
    get
    {
    if (propertyName == "XXXXConnectionString" || propertyName == "XXXXConnectionString3")
    {
    return Databases.SkarbDB.ConnectionString;
    }
    else
    {
    return base[propertyName];
    }
    }
    }
