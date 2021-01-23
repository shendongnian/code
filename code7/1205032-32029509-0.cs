    // Part 1
    sql.Append(
        DmlSqlGenerator.GenerateInsertSql(
            firstCommandTree,
            _sqlGenerator,
            out _,
            generateReturningSql: false,
            createParameters: false));
    
    sql.AppendLine();
    
    var firstTable
        = (EntityType)((DbScanExpression)firstCommandTree.Target.Expression).Target.ElementType;
    
    // Part 2
    sql.Append(IntroduceRequiredLocalVariables(firstTable, firstCommandTree));
    
    // Part 3
    foreach (var commandTree in commandTrees.Skip(1))
    {
        sql.Append(
            DmlSqlGenerator.GenerateInsertSql(
                commandTree,
                _sqlGenerator,
                out _,
                generateReturningSql: false,
                createParameters: false));
    
        sql.AppendLine();
    }
    
    var returningCommandTrees
        = commandTrees
            .Where(ct => ct.Returning != null)
            .ToList();
    
    // Part 4
    if (returningCommandTrees.Any())
    {
        //...
