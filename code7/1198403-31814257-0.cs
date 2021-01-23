    protected override DbEntityValidationResult ValidateEntity(
      DbEntityEntry entityEntry,
      IDictionary<object, object> items)
    {
      var result = base.ValidateEntity(entityEntry, items);
      var falseErrors = result.ValidationErrors
        .Where(error =>
        {
          var member = entityEntry.Member(error.PropertyName);
          var property = member as DbPropertyEntry;
          if (property != null)
            return !property.IsModified;
          else
            return false;//not false err;
        });
    
      foreach (var error in falseErrors.ToArray())
        result.ValidationErrors.Remove(error);
      return result;
    }
