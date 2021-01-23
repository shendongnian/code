    public static class SqlGeneratorExt
    {
        public static string InsertUpdateOnDuplicateKey(this ISqlGenerator generator, IClassMapper classMap, bool hasIdentityKeyWithValue = false)
        {
            var columns = classMap.Properties.Where(p => !(p.Ignored || p.IsReadOnly || (p.KeyType == KeyType.Identity && !hasIdentityKeyWithValue))).ToList();
            var keys = columns.Where(c => c.KeyType != KeyType.NotAKey).Select(p => $"{generator.GetColumnName(classMap, p, false)}=@{p.Name}");
            var nonkeycolumns = classMap.Properties.Where(p => !(p.Ignored || p.IsReadOnly) && p.KeyType == KeyType.NotAKey).ToList();
            if (!columns.Any())
            {
                throw new ArgumentException("No columns were mapped.");
            }
            var tablename = generator.GetTableName(classMap);
            var columnNames = columns.Select(p => generator.GetColumnName(classMap, p, false));
            var parameters = columns.Select(p => generator.Configuration.Dialect.ParameterPrefix + p.Name);
            var valuesSetters = nonkeycolumns.Select(p => $"{generator.GetColumnName(classMap, p, false)}=@{p.Name}").ToList();
            var where = keys.AppendStrings(seperator: " and ");
            var sqlbuilder = new StringBuilder();
            sqlbuilder.AppendLine($"IF EXISTS (select * from {tablename} WITH (UPDLOCK, HOLDLOCK) WHERE ({where})) ");
            sqlbuilder.AppendLine(valuesSetters.Any() ? $"UPDATE {tablename} SET {valuesSetters.AppendStrings()} WHERE ({where}) " : "SELECT 0 ");
            sqlbuilder.AppendLine($"ELSE INSERT INTO {tablename} ({columnNames.AppendStrings()}) VALUES ({parameters.AppendStrings()}) ");
            return sqlbuilder.ToString();
        }
    }
