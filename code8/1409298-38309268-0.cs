    try
    {
        db.SaveChanges();
    }
    catch (DbEntityValidationException e)
    {
        var errorMessages = e.EntityValidationErrors
            .SelectMany(x => x.ValidationErrors)
            .Select(x => x.ErrorMessage);
        var fullErrorMessage = string.Join("; ", errorMessages);
        var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
        throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
    }
