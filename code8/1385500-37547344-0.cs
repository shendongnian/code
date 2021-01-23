    public bool TryReturnSomething(..., out SomeType result) // ... - parameters
    {
        try
        {
            result = ReturnSomething();
            return true;
        }
        catch(SomeException1 e) { } // catch all expected exception types
        catch(SomeException2 e) { }
        return false;
    }
