    foreach (var item in EU)
    {
        var rows = objDataSet
                   .Tables[0]
                   .Select("NameOfColumn0 = " + item.Substring(1, item.Length - 1))
        {
            if (rows.Length > 0 && rows[0].Field<bool>("NameOfColumn1"))
                ExistingPhones.Add(item.Substring(1, item.Length - 1), true);
            else
                UpdatePhones.Add(item.Substring(1, item.Length - 1), true);
        }
        else
            ActivePhones.Add(item.Substring(1, item.Length - 1), true);
    }
