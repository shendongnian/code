    public List<string> GetValidationErrors()
    {
        var errors = new List<string>();
        foreach (var key in _notifyvalidationErrors.Keys)
        {
            errors.AddRange(_notifyvalidationErrors[key]);
     
            if (_privateValidationErrors.ContainsKey(key))
            {
                errors.AddRange(_privateValidationErrors[key]);
            }
        }
        return errors;
    }
     
    public string GetValidationErrorsString()
    {
        var errors = GetValidationErrors();
        var sb = new StringBuilder();
        foreach (var error in errors)
        {
            sb.Append("● ");
            sb.AppendLine(error);
        }
        return sb.ToString();
    }
