    PropertyItem pi = getPropertyItemByID(file, 0x9999);  // ! A fantasy Id for testing!
    if (pi != null)
    {
        Console.WriteLine( System.Text.Encoding.Default.GetString(pi.Value));
    }
