    public void Recalc()
    {
        var propertyInfos = GetType()
            .GetProperties()
            .Where(pInfo => pInfo.PropertyType.IsValueType);
        var fieldInfos = GetType()
            .GetFields()
            .Where(fInfo => fInfo.FieldType.IsValueType);
        //create a dictionary with all the old values
        //obtained from the backing fields.
        var oldValueDictionary = fieldInfos.ToDictionary(
            fInfo => fInfo.Name,
            fInfo => (decimal?)fInfo.GetValue(this));
        //set all properties to null
        foreach (var pInfo in propertyInfos)
            pInfo.SetValue(this, null);
        //call all the getters to calculate the new values
        foreach (var pInfo in propertyInfos)
            pInfo.GetValue(this);
        //compare new field values with the old ones stored in the dictionary;
        //if only one different is found, the if is entered.
        if (fieldInfos.Any(fInfo =>
            (decimal?)fInfo.GetValue(this) != oldValueDictionary[fInfo.Name]))
        {
            //do stuffs
        }
    }
