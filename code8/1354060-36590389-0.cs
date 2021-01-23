    for (int i = 0; i < noOfColumns; i++)
    {
        if (dr.Cells[i].Value == null)
            continue; //don't process
        if (i == 0)
        { dataRow[i] = DateTime.Parse(dr.Cells[i].Value.ToString()); }
        else if (i == 7)
        { dataRow[i] = int.Parse(dr.Cells[i].Value.ToString()); }
        else
        { dataRow[i] = dr.Cells[i].Value.ToString(); }
    }
