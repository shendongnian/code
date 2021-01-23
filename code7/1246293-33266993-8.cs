	public class Parent {
		public int Id {get; set; }
		public string Name {get; set; }
		public List<Child> Children {get; set; }
	}
	public class Child {
		public int Id {get; set; }
		public int ParentId {get; set; }
		public string Name {get; set; }
	} 
