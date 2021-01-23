	public class Entity
	{
		public virtual int Id { get; set; }
		public virtual int? ParentId { get; set; }
	}
	static void Main(string[] args)
	{
		Entity entity = Mock.Of<Entity>();
		var mock = Mock.Get<Entity>(entity);
		mock.Setup(e => e.ParentId).Returns(11);
		var result = entity.ParentId;
		// now result == 11
	}
