    static void DeleteColumnIfEmpty(Worksheet wkst, int colNo)
    {
        for (int i = 2; i <= wkst.UsedRange.Rows.Count; i++)
        {
            if (wkst.Cells[i, colNo].Value2 != null) return;
        }
        
        wkst.Columns[colNo].Delete();
    }
