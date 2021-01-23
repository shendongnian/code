    public class AddColumnIfNotExistsOperation : MigrationOperation
    {
    	public readonly string Table;
    	public readonly string Name;
    	public readonly ColumnModel ColumnModel;
    
    	public AddColumnIfNotExistsOperation(string table, string name, Func<ColumnBuilder, ColumnModel> columnAction, object anonymousArguments) : base(anonymousArguments)
    	{
    		ArgumentValidator.CheckForEmptyArgument(table, nameof(table));
    		ArgumentValidator.CheckForEmptyArgument(name, nameof(name));
    		ArgumentValidator.CheckForNullArgument(columnAction, nameof(columnAction));
    
    		Table = table;
    		Name = name;
    
    		ColumnModel = columnAction(new ColumnBuilder());
    		ColumnModel.Name = name;
    
    	}
    
    	public override bool IsDestructiveChange => false;
    
    	public override MigrationOperation Inverse => new DropColumnOperation(Table, Name, removedAnnotations: ColumnModel.Annotations.ToDictionary(s => s.Key,s => (object)s.Value) , anonymousArguments: null);
    }
