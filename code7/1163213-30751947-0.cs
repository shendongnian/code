    protected bool IsGroupValid(String sValidationGroup)
    {
        foreach (BaseValidator validator in Page.Validators)
           {
              if (validator.ValidationGroup == sValidationGroup)
                  {
                     bool fValid = validator.IsValid;
                     if (fValid)
                     {
                         validator.Validate();
                         fValid = validator.IsValid;
                         validator.IsValid = true;
                     }
                     if (!fValid)
                         return false;
                  }
             }
             return true;
    }
