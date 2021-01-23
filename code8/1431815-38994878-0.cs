    List<object> items = new List<object> { 1, 2 };
    object objectToRemove = null;
    foreach (var item in items)
    {
        // insert your condition
        if (false)
        {
            objectToRemove = item;
            break;
        }
    }
    if (objectToRemove != null)
        items.Remove(objectToRemove);
