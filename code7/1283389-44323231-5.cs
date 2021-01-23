    [TestClass]
    public class AddColumnIfNotExistsOperationTests
    {
    	[TestMethod]
    	public void Can_get_and_set_table_and_column_info()
    	{
    		Func<ColumnBuilder, ColumnModel> action = c => c.Decimal(name: "T");
    
    		var addColumnOperation = new AddColumnIfNotExistsOperation("T", "C", action, null);
    
    		Assert.AreEqual("T", addColumnOperation.Table);
    		Assert.AreEqual("C", addColumnOperation.Name);
    	}
    
    	[TestMethod]
    	public void Inverse_should_produce_drop_column_operation()
    	{
    		Func<ColumnBuilder, ColumnModel> action = c => c.Decimal(name: "C", annotations: new Dictionary<string, AnnotationValues> { { "A1", new AnnotationValues(null, "V1") } });
    
    		var addColumnOperation = new AddColumnIfNotExistsOperation("T", "C", action, null);
    
    		var dropColumnOperation = (DropColumnOperation)addColumnOperation.Inverse;
    
    		Assert.AreEqual("C", dropColumnOperation.Name);
    		Assert.AreEqual("T", dropColumnOperation.Table);
    		Assert.AreEqual("V1", ((AnnotationValues)dropColumnOperation.RemovedAnnotations["A1"]).NewValue);
    		Assert.IsNull(((AnnotationValues)dropColumnOperation.RemovedAnnotations["A1"]).OldValue);
    	}
    
    	[TestMethod]
    	[ExpectedException(typeof(ArgumentNullException))]
    	public void Ctor_should_validate_preconditions_tableName()
    	{
    		Func<ColumnBuilder, ColumnModel> action = c => c.Decimal(name: "T");
    		// ReSharper disable once ObjectCreationAsStatement
    		new AddColumnIfNotExistsOperation(null, "T", action, null);
    	}
    
    	[TestMethod]
    	[ExpectedException(typeof(ArgumentNullException))]
    	public void Ctor_should_validate_preconditions_columnName()
    	{
    		Func<ColumnBuilder, ColumnModel> action = c => c.Decimal();
    		// ReSharper disable once ObjectCreationAsStatement
    		new AddColumnIfNotExistsOperation("T", null, action, null);
    	}
    
    	[TestMethod]
    	[ExpectedException(typeof(ArgumentNullException))]
    	public void Ctor_should_validate_preconditions_columnAction()
    	{
    		// ReSharper disable once ObjectCreationAsStatement
    		new AddColumnIfNotExistsOperation("T", "C", null, null);
    	}
    }
