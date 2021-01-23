    public static class OrmLiteExtensions
    {
        public static void InitProtoTable<B>(this IDbConnection db)
            where B : IBuilder, new()
        {
            var desc = new B().DescriptorForType;
            var model = ModelDefinition<B>.Definition;
            model.Name = desc.Name;
            model.IgnoredFieldDefinitions.Clear();
            var fieldList = new List<FieldDefinition>();
            var fieldMap = desc.Fields
                .ToDictionary(f => f.Name, StringComparer.OrdinalIgnoreCase);
            foreach (var field in model.FieldDefinitions)
            {
                if (fieldMap.ContainsKey(field.Name)) fieldList.Add(field);
            }
            model.FieldDefinitions = fieldList;
            model.AfterInit();
            if (db.TableExists<B>())
            {
                var columns = GetColumnNames<B>(db, model.ModelName);
                var missing = model.FieldDefinitions
                    .Where(field => !columns.Contains(field.FieldName));
                foreach (var field in missing)
                {
                    field.DefaultValue = fieldMap[field.Name].DefaultValue.ToString();
                    db.AddColumn(typeof(B), field);
                    Console.WriteLine(db.GetLastSql());
                }
            }
        }
        private static HashSet<string> GetColumnNames<T>(IDbConnection db, string tableName)
        {
            using (var cmd = db.CreateCommand())
            {
                // Workaround to RDMS agnostic table column names discovery.
                cmd.CommandText = string.Format("SELECT * FROM {0} WHERE 1!=1", tableName);
                var table = new DataTable();
                table.Load(cmd.ExecuteReader());
                return new HashSet<string>(
                    table.Columns.OfType<DataColumn>().Select(c => c.ColumnName));
            }
        }
    }
