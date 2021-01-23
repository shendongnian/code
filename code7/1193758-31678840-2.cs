    try
    {
        knowledgebases.Update(knowledgebase);
        knowledgebases.Commit();
    }
    catch (DbEntityValidationException ex)
    {
        foreach (var validationErrors in ex.EntityValidationErrors)
        {
            foreach (var validationError in validationErrors.ValidationErrors)
            {
                Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            }
        }
    }
