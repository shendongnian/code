    public T Convert(string delimitedValues)
    {
        var valueType = typeof(T);
        var elementType = valueType;
        if (!valueType.IsArray)
        {
            throw new Exception("T is not an array");
        }
        if (valueType.HasElementType)
        {
            elementType = valueType.GetElementType();
        }
        var elements = delimitedValues.Split(',');
            
        var arrayToReturn = Array.CreateInstance(elementType, elements.Length);
        for (int i = 0; i < elements.Length; i++ )
        {
            var newElement = Enum.Parse(elementType, elements[i].Trim(), true);
            arrayToReturn.SetValue(newElement, i);
        }
        return (T)System.Convert.ChangeType(arrayToReturn, valueType);
    }
