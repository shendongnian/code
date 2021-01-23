    private void AddUpdate<T>(DataTable p_UpdateTable, string p_ColumnName, long p_uid, Maybe<T> p_value) {
        // ...
        if(existingRow != null) {
            if(p_value.HasValue)
                existingRow[p_ColumnName] = p_value.Value;
        }
        else {
            DataRow newRow = p_UpdateTable.NewRow();
            newRow["UID"] = p_uid;
            if(p_value.HasValue)
                newRow[p_ColumnName] = p_value.Value;
            p_UpdateTable.Rows.Add(newRow);
        }
        // ...
    }
