    decimal ColumnSumWhere(DataGridView dgv, int columnIndex, string region)
    {
        decimal sum = 0m;
        for (int row = 0; row < DGV.Rows.Count; row++)
           if (DGV[columnIndex, row].Value != null) &&
              (DGV[regionColumn, row].Value.ToString() == region)
                   sum += Convert.ToDecimal(DGV[1, row].Value);
        return sum;
    }
    
