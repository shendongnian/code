    DateTime temp;
    if (!DateTime.TryParse(values[0], out temp))
    {
        // parsing error.  notify the user?
    }
    Date = temp;
