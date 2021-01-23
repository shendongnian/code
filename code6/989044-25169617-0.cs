    try
    {
        context.SaveChanges();
    }
    catch (DbEntityValidationException ex)
    {
        var errorMessages = ex.EntityValidationErrors
            .SelectMany(x => x.ValidationErrors)
            .Select(x => x.ErrorMessage);
        var fullErrorMessage = string.Join("; ", errorMessages);
        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
    }
