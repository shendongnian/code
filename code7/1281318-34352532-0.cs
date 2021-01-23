    private void AddUpdate(DataTable p_UpdateTable, string p_ColumnName, long p_uid, object p_value)
    {
      if (!StronglyTypedDataSet.Columns.Contains(p_ColumnName))
      {
        throw new ArgumentException("Table '" + p_ColumnName + "' does not exist in table", "p_ColumnName");
      }
      if (!p_UpdateTable.Columns.Contains(p_ColumnName))
      {
        var matchingColumn = StronglyTypedDataSet.Columns.Cast<DataColumn>().Where(c => c.ColumnName.Equals(p_ColumnName)).First();
        DataColumn columnToAdd = p_UpdateTable.Columns.Add(p_ColumnName, matchingColumn.DataType);
        columnToAdd.MaxLength = matchingColumn.MaxLength;
        DataColumn setNullColumn = p_UpdateTable.Columns.Add(p_ColumnName + "_null", typeof(bool));
        setNullColumn.DefaultValue = false;
      }
      var existingRow = p_UpdateTable.Rows.Cast<DataRow>().Where(r => Convert.ToInt64(r["UID"]) == p_uid).FirstOrDefault();
      if (existingRow != null)
      {
        existingRow[p_ColumnName] = p_value;
        if (p_value == null || p_value == DBNull.Value)
        {
          existingRow[p_ColumnName + "_null"] = true;
        }
      }
      else
      {
        DataRow newRow = p_UpdateTable.NewRow();
        newRow["UID"] = p_uid;
        newRow[p_ColumnName] = p_value;
        if (p_value == null || p_value == DBNull.Value)
        {
          newRow[p_ColumnName + "_null"] = true;
        }
        p_UpdateTable.Rows.Add(newRow);
      }
    }
