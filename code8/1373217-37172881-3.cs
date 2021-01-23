        if (isDouble)
        {
            T Value = (T)(object)2.5; // does not compile
            Result.Add(Value);
        }
        else
        {
            T Value = (T)(object)2; // does not compile
            Result.Add(Value);
        }
