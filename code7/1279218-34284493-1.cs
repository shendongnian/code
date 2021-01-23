    interface ITable
    {
        ITable WithColumn(Action<IColumn> c);
    	ITable WithName(string tableName);	
    }
    
    interface IColumn
    {
    	IColumn WithName(string columnName);
        IColumn WithType(string typeName);
    }
    
    class TableBuilder : ITable
    {
    	public string TableName { get; set; }
        List<Column> Columns = new List<Column>();
    	
        public static ITable Create() { return new TableBuilder(); }
    	
    	public ITable WithName(string tableName)
    	{
    		TableName = tableName;
    		return this;
    	}
    	
    	public ITable WithColumn(Action<IColumn> c) 
    	{ 
    	 	Column thisColumn = new Column();
    		c(thisColumn);
            Columns.Add(thisColumn);
    
            return this;
    	}
    }
    
    class Column : IColumn
    {
        public string ColumnName { get; set; }
        public string TypeName { get; set; }
    
    	public IColumn WithName(string columnName)
    	{
    		ColumnName = columnName;
    		return this;
    	}
    
        public IColumn WithType(string typeName)
        {
            TypeName = typeName;
            return this;
        }
    }
