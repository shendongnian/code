    public bool IsValid(ObjectToBeValidated testObject)
        {
            return requiredExpressions.All(p => !string.IsNullOrEmpty(p.Compile().Invoke(testObject)))
                && rangeExpressions.All(p => p.Compile().Invoke(testObject));
        }
