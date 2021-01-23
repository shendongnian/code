	void Main()
	{
		var entities = Observable.Defer(() => GetObservable().Concat());
		Entity result = null;
		var first = entities.FirstOrDefaultAsync(i => i.RowId == 1).Subscribe(i => result = i);
		result.Dump();
		buildCalled.Dump();
	}
	
	// Define other methods and classes here
	
	public IEnumerable<IObservable<Entity>> GetObservable()
	{
		var rows = new List<EntityTableRow>
		{
			new EntityTableRow { Id = 1, StringVal = "One"},
			new EntityTableRow { Id = 2, StringVal = "Two"},
		};
		return rows.Select(i => Observable.Return(BuildEntity(i)));
	}
	
	public int buildCalled = 0;
	public Entity BuildEntity(EntityTableRow entityRow)
	{
		buildCalled++;
		return new Entity { RowId = entityRow.Id, StringVal = entityRow.StringVal };
	}
	
	public class Entity
	{
		public int RowId { get; set; }
		public string StringVal { get; set; }
	}
	
	public class EntityTableRow
	{
		public int Id { get; set; }
		public string StringVal { get; set; }
	}
