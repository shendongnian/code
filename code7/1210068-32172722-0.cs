    var existingEntityQuery = myContext.Set(validationContext.ObjectType)
         .Where("Name= @0", (string)value);
    var enumerator = existingEntityQuery.GetEnumerator();
    if (enumerator.MoveNext())
    {
        var entity = enumerator.Current;
        if (entity != null)
        {
             return new ValidationResult("The name already exist", propertiesList);
        }
    }
