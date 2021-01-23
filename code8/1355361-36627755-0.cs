    namespace Extensions
    {
        public static class DataGridExtension
        {
    		IEnumerable<FrameworkElement> GetItemsInColumn(this DataGrid dg, int col)
            {
                if (dg.Columns.Count <= col)
                    throw new IndexOutOfRangeException("Column " + col + " is out range, the datagrid only contains " + dg.Columns.Count + " columns.");
    			foreach (object item in dg.Items)
                {
    				yield return dg.Columns[col].GetCellContent(item);
                }
            }
        }
    }
