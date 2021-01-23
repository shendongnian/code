    public static class SqlGeneratorExt
    {
      public static string InsertUpdateOnDuplicateKey(this ISqlGenerator generator, IClassMapper classMap, bool hasIdentityKeyWithValue=false)
      {
        var columns = classMap.Properties.Where(p => !(p.Ignored || p.IsReadOnly || (p.KeyType == KeyType.Identity && !hasIdentityKeyWithValue))).ToList();
        if (!columns.Any()) { throw new ArgumentException("No columns were mapped."); }
        var nonkeycolumns = classMap.Properties.Where(p => !(p.Ignored || p.IsReadOnly) && p.KeyType==KeyType.NotAKey).ToList();   
        var tablename = generator.GetTableName(classMap);
        var columnNames = columns.Select(p => generator.GetColumnName(classMap, p, false));
        var parameters = columns.Select(p => generator.Configuration.Dialect.ParameterPrefix + p.Name);
        var parametersstring = $"({parameters.AppendStrings()})";
        var valuesSetters = nonkeycolumns.Select(p => $"{generator.GetColumnName(classMap, p, false)}=@{p.Name}");
        var updatevaluestring = valuesSetters.AppendStrings();
        var setcolumnstring = $"({columnNames.AppendStrings()})";
        var keys = columns.Where(c => c.KeyType != KeyType.NotAKey).Select(p=> $"{generator.GetColumnName(classMap,p,false)}=@{p.Name}");
        var wherekeystring=keys.AppendStrings(seperator:" and ");
        var sqlbuilder=new StringBuilder();
        sqlbuilder.AppendLine($"IF EXISTS (select * from {tablename} WITH (UPDLOCK, HOLDLOCK) WHERE ({wherekeystring})) ");
        sqlbuilder.AppendLine($"BEGIN UPDATE {tablename} SET {updatevaluestring} WHERE ({wherekeystring}) END");
        sqlbuilder.AppendLine($"ELSE BEGIN INSERT INTO {tablename} {setcolumnstring} VALUES {parametersstring} END");
        return sqlbuilder.ToString();
      }
    }
