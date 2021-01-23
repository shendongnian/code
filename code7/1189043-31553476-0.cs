    public class CustomSqlGenerator : SqlServerMigrationSqlGenerator
    {
    	protected override void Generate(AddForeignKeyOperation addForeignKeyOperation)
    	{
    		addForeignKeyOperation.Name = getFkName(addForeignKeyOperation.PrincipalTable,
    			addForeignKeyOperation.DependentTable, addForeignKeyOperation.DependentColumns.ToArray());
    		base.Generate(addForeignKeyOperation);
    	}
    
    	protected override void Generate(DropForeignKeyOperation dropForeignKeyOperation)
    	{
    		dropForeignKeyOperation.Name = getFkName(dropForeignKeyOperation.PrincipalTable,
    			dropForeignKeyOperation.DependentTable, dropForeignKeyOperation.DependentColumns.ToArray());
    		base.Generate(dropForeignKeyOperation);
    	}
    
    	private static string getFkName(string primaryKeyTable, string foreignKeyTable, params string[] foreignTableFields)
    	{
    		// Return any format you need
    	}
    }
