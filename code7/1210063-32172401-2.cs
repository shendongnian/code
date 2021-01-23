    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var db = new YourDBContext();
        var className = validationContext.ObjectType.Name.Split('.').Last();
        var propertyName = validationContext.MemberName;
        var parameterName = string.Format("@{0}", propertyName);
        var count = db.Database.ExecuteSqlCommand(
            string.Format("SELECT COUNT(*) FROM {0} WHERE {1}={2}", className, propertyName, parameterName),
            new System.Data.SqlClient.SqlParameter(parameterName, value));
        if (count > 0)
        {
            return new ValidationResult(string.Format("The '{0}' already exist", propertyName),
                       new List<string>(){ propertyName });
        }
        return null;
    }
