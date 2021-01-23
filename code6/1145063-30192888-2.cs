        public DataSet GetYesNoValue(string ColumnName)
        {
            DataTable dtVal = new DataTable();
            DataColumn column;
            DataRow row;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = ColumnName;
            dtVal.Columns.Add(column);
            DataSet dsVal = new DataSet();
            dtVal.Rows.Add("--Select--");
            dtVal.Rows.Add("Yes");
            dtVal.Rows.Add("No");
            dsVal.Tables.Add(dtVal);
            return dsVal;
        }
          
    
