    public DataColumn[] PrimaryKey
    {
    	get
    	{
    		UniqueConstraint uniqueConstraint = this.primaryKey;
    		if (uniqueConstraint != null)
    		{
    			return uniqueConstraint.Key.ToArray();
    		}
    		return DataTable.zeroColumns;
    	}
            // setter ...
    // System.Data.DataTable
    internal static readonly DataColumn[] zeroColumns = new DataColumn[0];
