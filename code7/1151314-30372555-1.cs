    private void YourThreadMethod(object state)
    {
        // long taking operation
        lock (dictionary)
        {
            if (!dictionary.ContainsKey(yourItemKey))
            {
                // construct object, long taking operation
                dictionary.Add(yourItemKey, createdObject);
            }
        }
    }
