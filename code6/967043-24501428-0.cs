    public List<string> ValidationErrorList = new List<string>();
    try
    {
      _context.SaveChanges();
    }
    catch (Exception)
    {
      GetErrors(_context);
    }
    private void GetErrors(System.Data.Entity.DbContext context)
    {
      IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> ve;
      ve = context.GetValidationErrors();
      ValidationErrorList.Clear();
      foreach (var vr in ve)
      {
        if (vr.IsValid == false)
        {
          foreach (var e in vr.ValidationErrors)
          {
            var errorMessage = e.PropertyName.Trim() + " : " +
                               e.ErrorMessage;
            ValidationErrorList.Add(errorMessage);
          }
        }
      }
    }
