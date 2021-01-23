    string tot = "19950000";
    int totInt;
    if (Int32.TryParse(tot, out totInt))
    {
        string output = totInt.ToString("n2", CultureInfo.CreateSpecificCulture("en-GB"));
        MessageBox.Show(output);
    }
    else
    {
        MessageBox.Show("tot could not be parsed to an Int32");
    }
