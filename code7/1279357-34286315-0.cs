    for (int rowIndex = 0; rowIndex < csvData.Rows.Count; rowIndex++)
    {
        DateTime dt2 = csvData.Rows[rowIndex].Field<DateTime>(2);
        DateTime newDate = dt2.AddDays(1);
        csvData.Rows[rowIndex][2] = newDate;                                    
    }
