    public int MyApiMethod()
    {
        using (new ExecutionTimeLogger())
        {
            // All API functionality goes inside this using.
            return theResultValue;
        }
    }
