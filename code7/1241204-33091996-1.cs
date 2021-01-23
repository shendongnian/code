    using (var iterator = GetItems(...).GetEnumerator())
    {
        if (iterator.MoveNext())
        {
            // Take your "pre-iteration" action
        }
        do
        {
            var item = iterator.Current;
            // Use the item
        } while (iterator.MoveNext());
    }
