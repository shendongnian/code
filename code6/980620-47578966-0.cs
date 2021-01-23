        public void Clear_DataTableEmptyRows(DataTable dataTableControl)
        {
            for (int i = dataTableControl.Rows.Count - 1; i >= 0; i--)
            {
                DataRow currentRow = dataTableControl.Rows[i];
                foreach (var colValue in currentRow.ItemArray)
                {
                    if (!string.IsNullOrEmpty(colValue.ToString()))
                        break;
                    dataTableControl.Rows[i].Delete();
                    break;
                }
            }
        }
