    for (int i = 0; i < seconddt.Rows.Count; i++)
    {
        bool isRecord = firstdt.AsEnumerable()
                        .Any(x => Convert.ToInt32(x["ID"]) == 
                                  Convert.ToInt32(seconddt.Rows[i]["ID"]));
        if (isRecord)
        {
            //Add Record.
        }
    }
    
