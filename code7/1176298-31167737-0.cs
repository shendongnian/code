    public int GetAll(List<Error> errors, string applicationName = null)
    {
        if (_isInRetry)
        {
            errors.AddRange(WriteQueue);
            return errors.Count;
        }
        try { return GetAllErrors(errors, applicationName); }
        catch (Exception ex) { BeginRetry(ex); }
        return 0;
    }
