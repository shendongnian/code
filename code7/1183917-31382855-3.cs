    public bool IsValid(ObjectToBeValidated testObject)
        {
            return requiredExpressions.All(p => p.Compile().Invoke(testObject))
                && rangeExpressions.All(p => p.Compile().Invoke(testObject));
        }
