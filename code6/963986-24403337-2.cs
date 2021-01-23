    private static string GetInsertString<TDto>(TDto dto)
    {
        var type = typeof(TDto);
        var propertyNames = type.GetProperties().Where(Where).Select(x => x.Name);
        return string.Format("INSERT INTO {0} ({1}) VALUES ({2});",
            type.Name,
            string.Join(",", propertyNames),
            string.Join(",", propertyNames.Select(x => string.Format("@{0}", x.ToLower())));
    }
