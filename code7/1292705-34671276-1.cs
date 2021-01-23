    public BusinessRuleValidationException(string message, bool isVerified)
        : base(message) // <- problem is here
    {
        if (isVerified)
            message += " The change has not been committed.";
    }
