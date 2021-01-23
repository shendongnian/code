    void ICollection.CopyTo(Array array, int index)
    {
        if (array != null && array.Rank != 1)
            throw new ArgumentException("Only single dimensional arrays are supported for the requested action.", "array");
        // 1. call the generic version
        T[] typedArray = array as T[];
        if (typedArray != null)
        {
            CopyTo(typedArray, index);
            return;
        }
        // 2. object[]
        object[] objectArray = array as object[];
        if (objectArray != null)
        {
            for (int i = 0; i < size; i++)
            {
                objectArray[index++] = GetElementAt(i);
            }
        }
        throw new ArgumentException("Target array type is not compatible with the type of items in the collection.");
    }
