    public static bool CheckForNumbersInNumbersColumns(DataGridView datagridviewname)
    {
        for (int i = 0; i < datagridviewname.Rows.Count; i++)
        {
            var value = datagridviewname.Rows[i].Cells[7].Value.ToString();
            var value2 = datagridviewname.Rows[i].Cells[8].Value.ToString();
            float floatValue;
            float floatValue2;
    
            if (!Single.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out floatValue) || 
                !Single.TryParse(value2, NumberStyles.Any, CultureInfo.InvariantCulture, out floatValue2))
            {
                return true;
            }
        }
        return false;
    }
