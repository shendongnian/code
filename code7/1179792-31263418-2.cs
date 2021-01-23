    public static class DataTableExtensions
    {
        public static List<object> DataTableToList(this DataTable table, Type type)
        {
            List<object> list = new List<object>();
            foreach (var row in table.AsEnumerable())
            {
                object obj = Activator.CreateInstance(type);
                foreach (var field in obj.GetType().GetFields())
                {
                    FieldInfo fieldInfo = obj.GetType().GetField(field.Name);
                    fieldInfo.SetValue(obj, Convert.ChangeType(row[field.Name], fieldInfo.FieldType));
                }
                list.Add(obj);
            }
            return list;
        }
    }
    class Program
    {
        private static void Main(string[] args)
        {
            var cb = new FixedLengthClassBuilder("Customer");
            cb.AddField("BirthDate", 8, typeof(DateTime));
            cb.LastField.Converter.Kind = ConverterKind.Date;
            cb.LastField.Converter.Arg1 = "ddMMyyyy";
            cb.LastField.FieldNullValue = DateTime.Now;
            cb.AddField("Name", 3, typeof(string));
            cb.AddField("Age", 3, typeof(int));
            cb.LastField.TrimMode = TrimMode.Both;
            Type recordClass = cb.CreateRecordClass();
            var dataTable = new DataTable("Customer");
            dataTable.Columns.Add("BirthDate", typeof(DateTime));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Age", typeof(int));
            dataTable.Rows.Add(new DateTime(1972, 8, 14), "Joe", 42);
            dataTable.Rows.Add(new DateTime(1971, 9, 15), "Tine", 43);
            var list = dataTable.DataTableToList(recordClass);
            var engine = new FileHelperEngine(recordClass);
            engine.WriteFile(filename, list);
            Console.ReadKey();
        }
    }
