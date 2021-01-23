    public static void Process(ExcitingResults result) {
        var propertiesByRank = typeof(ExcitingResults)
            .GetProperties()
            .OrderBy(x => x.GetCustomAttribute<ColumnAttribute>().Rank);
            
        foreach (var propertyInfo in propertiesByRank) {
            var property = result.GetType().GetProperty(propertyInfo.Name);
            var propertysFriendlyName = property.GetCustomAttribute<ColumnAttribute>().FriendlyName;
            var propertysValue = property.GetValue(result, null);
            Console.WriteLine($"{propertysFriendlyName} = {propertysValue}");
        }
    }
