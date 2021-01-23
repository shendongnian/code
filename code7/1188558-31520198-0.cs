    public static DataTable ToDataTable<T>(this IEnumerable<T> data)
            {
                if (data == null)
                    throw new ArgumentNullException("data");
                var table = new DataTable("sd");
                using (var reader = ObjectReader.Create(data))
                {
                    table.Load(reader);
                }
                return table;
            }
