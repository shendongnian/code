    public static Array ResizeArray (Array oldArray, int newSize)
        int oldSize = oldArray.Length;
        Type elementType = oldArray.GetType().GetElementType();
        Array newArray = Array.CreateInstance(elementType,newSize);
        int preserveLength = System.Math.Min(oldSize,newSize);
        if (preserveLength > 0){
            Array.Copy (oldArray,newArray,preserveLength);
        }
        retuen newArray;
    }
