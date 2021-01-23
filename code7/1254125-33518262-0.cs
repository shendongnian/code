    var pickers = pickersPool.Values;
    var pickerIterator = pickers.GetEnumerator();
    foreach (var ticket in tickets)
    {
        if (!pickerIterator.MoveNext())
        {
            // Start the next picker...
            pickerIterator = pickers.GetEnumerator();
            if (!pickerIterator.MoveNext())
            {
                throw new InvalidOperationException("No pickers available!");
            }
        }
        ticketToPickerMap[ticket] = pickerIterator.Current;
    }
