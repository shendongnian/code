	public class Layer
	{
		public string Name { get; set; }
		public int Priority { get; set; }
	
		public Something Head { get; set; }
		public Something Add(Something s) { 
            if (this.Head == null) this.Head = s; 
            s.Layer = this; 
            this.Items.Add(s); 
            return s; 
        }
		public Something this[int id] { 
            get { return this.Items.SingleOrDefault(s => s.Id == id); } 
        }
		public List<Something> Items = new List<Something>();
		
		private void BuildTree(List<Something> list, Something s = null)
		{
			list.Add(s);
			foreach(Something ss in s.Followers.OrderBy(sss => sss.Layer.Priority))
			{
				BuildTree(list, ss);
			}
		}
		public List<Something> Tree
		{
			get 
			{
				List<Something> list = new List<Something>();
				if (this.Head != null) BuildTree(list, this.Head);
				return list;
			}
		}
	}
	
	public class Something
	{
		public int Id { get; set; }
		public Layer Layer { get; set; }
		public List<Something> Followers = new List<Something>();
		public void Follows(Something s) { s.Followers.Add(this); }
	}
	
	void Main()
	{
		Layer A = new Layer() { 
			Name="A", 
			Priority = 3
		};
		A.Add(new Something() { Id = 1 });
		A.Add(new Something() { Id = 2 }).Follows(A[1]);
		A.Add(new Something() { Id = 3 }).Follows(A[2]);
		A.Add(new Something() { Id = 4 }).Follows(A[3]);
		A.Add(new Something() { Id = 5 }).Follows(A[4]);
		A.Add(new Something() { Id = 6 }).Follows(A[5]);
		
		Layer B = new Layer() { 
			Name = "B",
			Priority = 2
		};
		B.Add(new Something() { Id = 7 });
		B.Add(new Something() { Id = 8 }).Follows(B[7]);
		B.Add(new Something() { Id = 9 }).Follows(A[2]);
		B.Add(new Something() { Id = 12 }).Follows(B[9]);
		
		Layer C = new Layer() {
			Name = "C",
			Priority = 1
		};
		C.Add(new Something() { Id = 14 });
		C.Add(new Something() { Id = 15 }).Follows(C[14]);
		C.Add(new Something() { Id = 17 }).Follows(C[15]);
		C.Add(new Something() { Id = 18 }).Follows(B[9]);
		C.Add(new Something() { Id = 19 }).Follows(C[18]);
	
		List<Something> orderedItems = new List<Something>();
		List<Layer> layers = new List<Layer>() { A, B, C };
		foreach(Layer l in layers.OrderBy(ll => ll.Priority)) orderedItems.AddRange(l.Tree);
	}
