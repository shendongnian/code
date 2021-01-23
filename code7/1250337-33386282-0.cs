    void Search()
    {
        ConfigurationObjectBase[] array = { someObject1, someObject2, null, someObject3 };
        foreach (var item in array)
        {
            if (item.ID == 12) return item;
            // here, if item is null, you will try to access its ID and get NullReferenceException
        }
        throw new InvalidOperationException("Sequence contains no matching elements");
    }
