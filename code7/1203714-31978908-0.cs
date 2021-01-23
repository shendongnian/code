	public class TestObject
	{
		public string name { get; set; }
		public TestObjectCollection testObjects{ get; set; } 
	}
	public class TestObjectCollection : CollectionBase
	{
		public void Add(TestObject to)
		{
			this.List.Add(to);
		}
	}
	void Main()
	{
		TestObjectCollection children = new TestObjectCollection();
		TestObject child = new TestObject { name = "child" };
		children.Add(child);
		
		TestObject parent = new TestObject { name = "parent", testObjects = children };	
		TestObject otherParent = new TestObject { name = "otherParent", testObjects = children };	
		TestObject stepParent = new TestObject { name = "stepParent", testObjects = children };	
		TestObject inLocoParentis = new TestObject { name = "inLocoParentis", testObjects = children };
        // and we can keep going on and on and on ...	
	}
