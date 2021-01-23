    //First populate the X axis only (the series)
    for (int index = 0; index < table.Rows.Count; index++)
    {
        XPointMember[index] = table.Rows[index]["GuitarBrand"].ToString();
    }
    //Loop again, and for each series, use the Count method
    //to see how much occurrences of the same guitar brand are there
    for (int index = 0; index < table.Rows.Count; index++)
    {
        var guitar_brand = XPointMember[index];
        YPointMember[index] = XPointMember.Count(x => x == guitar_brand);
    }
