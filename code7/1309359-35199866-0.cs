        public static class DataTableExtensions
        {
            public static void SetCellValue<T>(this DataTable table, int row, string col, T value)
            {
               lock (table)
               {
                  table.Rows[row][col] = value;
               }
            }
        }
