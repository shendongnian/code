    static bool EqualKeys(DataGridViewRow x, DataGridViewRow y, string[] keyNames)
    {
        foreach (var keyName in keyNames)
            if (!Equals(x.Cells[keyName].Value, y.Cells[keyName].Value)) return false;
        return true;
    }
    static bool IsDuplicateRow(DataGridView dg, int rowIndex, string[] keyNames)
    {
        var row = dg.Rows[rowIndex];
        for (int i = rowIndex - 1; i >= 0; i--)
            if (EqualKeys(row, dg.Rows[i], keyNames)) return true;
        return false;
    }
    static bool IsDuplicateRowCell(DataGridView dg, int rowIndex, int columnIndex, string[] keyNames)
    {
        return keyNames.Contains(dg.Columns[columnIndex].Name) &&
            IsDuplicateRow(dg, rowIndex, keyNames);
    }
