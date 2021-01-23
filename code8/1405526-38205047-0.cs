       public static class SqlGeneratorExt
        {
            public static string InsertUpdateOnDuplicateKey(this ISqlGenerator generator, IClassMapper classMap)
            {
                var columns = classMap.Properties.Where(p => !(p.Ignored || p.IsReadOnly || p.KeyType == KeyType.Identity));
                if (!columns.Any())
                {
                    throw new ArgumentException("No columns were mapped.");
                }
    
                var columnNames = columns.Select(p => generator.GetColumnName(classMap, p, false));
                var parameters = columns.Select(p => generator.Configuration.Dialect.ParameterPrefix + p.Name);
                var valuesSetters = columns.Select(p => string.Format("{0}=VALUES({1})", generator.GetColumnName(classMap, p, false), p.Name));
    
                string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2}) ON DUPLICATE KEY UPDATE {3}",
                                           generator.GetTableName(classMap),
                                           columnNames.AppendStrings(),
                                           parameters.AppendStrings(),
                                           valuesSetters.AppendStrings());
    
                return sql;
            }
        }
