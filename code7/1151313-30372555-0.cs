    private void YourThreadMethod(object state)
    {
        // long taking operation
        lock (list)
        {
            if (!list.Contains(yourItemKey))
            {
                list.Add(yourItemKey);
            }
        }
    }
