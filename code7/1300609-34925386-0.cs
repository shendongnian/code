     if (db.GetValidationErrors().Count() > 0)
     {
        var errorString = db.GetValidationErrorsString();
     }
     public static string GetValidationErrorsString(this DbContext dbContext)
    {
        var validationErrors = dbContext.GetValidationErrors();
        string errorString = string.Empty;
        foreach (var error in validationErrors)
        {
            foreach (var innerError in error.ValidationErrors)
            {
                errorString += string.Format("Property: {0}, Error: {1}<br/>", innerError.PropertyName, innerError.ErrorMessage);
            }
        }
        return errorString;
    }
