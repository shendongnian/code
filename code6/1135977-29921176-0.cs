        foreach (var array in list.Skip(1))
        {
            var NewRow = table.NewRow();
            for (int i = 0; i < columnNames.Count; i++)
            {
                NewRow[columnNames[i]] = array[i];
            }
            table.Rows.Add(NewRow);
        }
