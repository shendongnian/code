	public class LowercaseSqlGenerationHelper : RelationalSqlGenerationHelper
	{
		public LowercaseSqlGenerationHelper(RelationalSqlGenerationHelperDependencies dependencies) : base(dependencies)
		{
		}
		public override void DelimitIdentifier(StringBuilder builder, string identifier)
		{
			base.DelimitIdentifier(builder, identifier.FromPascalCaseToSnakeCase());
		}
		public override void DelimitIdentifier(StringBuilder builder, string name, string schema)
		{
			base.DelimitIdentifier(builder, name.FromPascalCaseToSnakeCase(), schema.FromPascalCaseToSnakeCase());
		}
		public override string DelimitIdentifier(string identifier)
		{
			return base.DelimitIdentifier(identifier.FromPascalCaseToSnakeCase());
		}
		public override string DelimitIdentifier(string name, string schema)
		{
			return base.DelimitIdentifier(name.FromPascalCaseToSnakeCase(), schema.FromPascalCaseToSnakeCase());
		}
	}
	public class LowercaseQuerySqlGenerator : NpgsqlQuerySqlGenerator
	{
		public LowercaseQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies, RelationalSqlGenerationHelperDependencies rSGenDep, SelectExpression selectExpression) : 
			base(
				new QuerySqlGeneratorDependencies(dependencies.CommandBuilderFactory, 
					new LowercaseSqlGenerationHelper(rSGenDep), 
					dependencies.ParameterNameGeneratorFactory, 
					dependencies.RelationalTypeMapper)
				, selectExpression)
		{
		}
	}
    public class LowercaseHistoryRepository:NpgsqlHistoryRepository
    {
	    public LowercaseHistoryRepository(HistoryRepositoryDependencies dependencies) : base(dependencies)
	    {
	    }
	    protected override string ExistsSql
	    {
		    get
		    {
			    var builder = new StringBuilder();
			    builder.Append("SELECT EXISTS (SELECT 1 FROM pg_catalog.pg_class c JOIN pg_catalog.pg_namespace n ON n.oid=c.relnamespace WHERE ");
			    if (TableSchema != null)
			    {
				    builder
					    .Append("n.nspname='")
					    .Append(SqlGenerationHelper.EscapeLiteral(TableSchema.FromPascalCaseToSnakeCase()))
					    .Append("' AND ");
			    }
			    builder
				    .Append("c.relname='")
				    .Append(SqlGenerationHelper.EscapeLiteral(TableName.FromPascalCaseToSnakeCase()))
				    .Append("');");
			    return builder.ToString();
		    }
	    }
    }
