    DateTime startCompare = dateTimeGet.Date.AddHours(15);
    DateTime endCompare = dateTimeGet.Date.AddHours(21);
    if ((endCompare > dateTimeGet) && (startCompare < dateTimeGet))
    {
        // match found
    }
