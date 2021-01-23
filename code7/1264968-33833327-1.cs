    public bool HasErrors
    {
        get { return _validationErrors.Count > 0 ||
              GetValidableProperties().Any(x => x.HasErrors); }
    }
