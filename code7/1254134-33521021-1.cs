    var pickerIterator = pickerPool.GetEnumerator();
    foreach (DictionaryEntry ticket in tickets)
    {
        if (!pickerIterator.MoveNext())
        {
            // Start the next picker...
            pickerIterator = pickerPool.GetEnumerator();
            if (!pickerIterator.MoveNext())
            {
                throw new InvalidOperationException("No pickers available!");
            }
        }
        ticketToPickerMap[ticket.Key] = pickerIterator.Value.ToString();
    }
