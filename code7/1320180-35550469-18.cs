    public int MyApiMethod()
    {
        using (new ExecutionTimeLogger())
        {
            // All API functionality goes inside this using block.
            var theResultValue = 23;
            return theResultValue;
        }
    }
