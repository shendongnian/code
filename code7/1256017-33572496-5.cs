    private void MyFunction<T>(T[] data) 
    {   
        var ops = GetOperations<T>();
        ops.Scale(data, 5);
    }
    IArithmeticOperations<T> GetOperations<T>()
    { 
        object result;
        if (T is double)
        {
            result = new DoubleArithmeticOperations();  
        }
        else if (T is int)
        {
             result = new IntArithmeticOperations();  
        }
        else 
        {
            throw new InvalidOperationException("Unsupported type");
        }
        return (IArithmeticOperation<T>) result;
    }
