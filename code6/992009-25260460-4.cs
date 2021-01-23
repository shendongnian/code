    #region IDataErrorInfo Implementation.
    /// <summary>
    /// Access to the error.
    /// </summary>
    string IDataErrorInfo.Error
    {
        get { return String.Empty; }
    }
    /// <summary>
    /// Get the validation error.
    /// </summary>
    /// <param name="propertyName">The name of the property to validate.</param>
    /// <returns>The error information as a string.</returns>
    string IDataErrorInfo.this[string propertyName]
    {
        get { return ExecuteValidation(); }
    }
    /// <summary>
    /// Run validation routines.
    /// </summary>
    /// <returns>Error message.</returns>
    private string ExecuteValidation()
    {
        // Put validation for the other TextBox here.
        return String.Empty;
    }
    #endregion // IDataErrorInfo Implementation.
