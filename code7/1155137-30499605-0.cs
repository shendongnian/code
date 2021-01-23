        static string GetMyColumnName(DataView objDataView, object YOURVALUE)
        {
            int colCount = objDataView.Table.Columns.Count;
            foreach (DataRowView rowView in objDataView)
            {
                for (int i = 0; i < colCount; i++)
                    if (rowView[i] == YOURVALUE) // Check if cell value is the one you are looking for
                        return objDataView.Table.Columns[i].ColumnName;
            }
            throw new Exception("Column not found");
        }
