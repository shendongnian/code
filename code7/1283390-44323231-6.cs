    [TestClass]
    public class AddColumnIfNotExistsSqlGeneratorTests
    {
    	[TestMethod]
    	public void AddColumnIfNotExistsSqlGenerator_Generate_can_output_add_column_statement_for_GUID_and_uses_newid()
    	{
    		var migrationSqlGenerator = new AddColumnIfNotExistsSqlGenerator();
    
    
    		Func<ColumnBuilder, ColumnModel> action = c => c.Guid(nullable: false, identity: true, name: "Bar");
    
    
    		var addColumnOperation = new AddColumnIfNotExistsOperation("Foo", "bar", action, null);
    
    		var sql = string.Join(Environment.NewLine, migrationSqlGenerator.Generate(new[] {addColumnOperation}, "2005")
    			.Select(s => s.Sql));
    
    
    		Assert.IsTrue(sql.Contains("IF NOT EXISTS(SELECT 1 FROM sys.columns"));
    		Assert.IsTrue(sql.Contains("WHERE Name = N\'bar\' AND Object_ID = Object_ID(N\'[Foo]\'))"));
    		Assert.IsTrue(sql.Contains("BEGIN"));
    		Assert.IsTrue(sql.Contains("ALTER TABLE"));
    		Assert.IsTrue(sql.Contains("[Foo]"));
    		Assert.IsTrue(sql.Contains("ADD [bar] [uniqueidentifier] NOT NULL DEFAULT newsequentialid()END"));
    	}
    }
