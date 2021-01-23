    catch (DbEntityValidationException dbEx)
    {
        var sb = new StringBuilder();
        foreach (var validationErrors in dbEx.EntityValidationErrors)
        {
            foreach (var validationError in validationErrors.ValidationErrors)
            {
                sb.AppendLine(string.Format("Entity:'{0}' Property: '{1}' Error: '{2}'",
                                  validationErrors.Entry.Entity.GetType().FullName,
                                  validationError.PropertyName,
                                  validationError.ErrorMessage));
            }
        }
        throw new Exception(string.Format("Failed saving data: '{0}'", sb.ToString()), dbEx);
    }
