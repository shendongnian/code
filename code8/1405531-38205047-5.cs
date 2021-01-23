    public class Db : Database
    {
    	private readonly IDapperImplementor _dapperIml;
    
    	public Db(IDbConnection connection, ISqlGenerator sqlGenerator) : base(connection, sqlGenerator)
    	{
    		_dapperIml = new DapperImplementor(sqlGenerator);
    	}
    
    	public void InsertUpdateOnDuplicateKey<T>(IEnumerable<T> entities, int? commandTimeout) where T : class
    	{
    		_dapperIml.InsertUpdateOnDuplicateKey(Connection, entities, commandTimeout);
    	}
    }
