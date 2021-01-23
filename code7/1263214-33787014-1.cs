        public static DataTable ToDataTable<T>(List<T> data)
        {
            FieldInfo[] fields = typeof(T).GetFields();
            DataTable table = new DataTable();
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo FI = fields[i];
                table.Columns.Add(FI.Name, FI.FieldType);
            }
            object[] values = new object[fields.Length];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = fields[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
