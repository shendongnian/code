    internal static string GenerateSql(DbCommandTree tree, SqlVersion sqlVersion, out List<SqlParameter> parameters, out CommandType commandType, out HashSet<string> paramsToForceNonUnicode)
    {
        SqlGenerator sqlGen;
        commandType = CommandType.Text;
        parameters = null;
        paramsToForceNonUnicode = null;
    
        switch (tree.CommandTreeKind)
        {
            case DbCommandTreeKind.Query:
                sqlGen = new SqlGenerator(sqlVersion);
                return sqlGen.GenerateSql((DbQueryCommandTree)tree, out paramsToForceNonUnicode);
                
            case DbCommandTreeKind.Insert:
                return DmlSqlGenerator.GenerateInsertSql((DbInsertCommandTree)tree, sqlVersion, out parameters);
    
            case DbCommandTreeKind.Delete:
                return DmlSqlGenerator.GenerateDeleteSql((DbDeleteCommandTree)tree, sqlVersion, out parameters);
    
            case DbCommandTreeKind.Update:
                return DmlSqlGenerator.GenerateUpdateSql((DbUpdateCommandTree)tree, sqlVersion, out parameters);
    
            case DbCommandTreeKind.Function:
                sqlGen = new SqlGenerator(sqlVersion);
                return GenerateFunctionSql((DbFunctionCommandTree)tree, out commandType);
    
            default:
                //We have covered all command tree kinds
                Debug.Assert(false, "Unknown command tree kind");
                parameters = null;
                return null;
        }
    }
