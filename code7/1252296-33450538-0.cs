	void Main()
	{
		var foo_list = new List<Foo>();
		foo_list.Add(new Foo(){InnerList = new List<Bar> {
			new Bar{Pro=true, Ind =1},
			new Bar{Pro=true, Ind =2},
			new Bar{Pro=false, Ind =3}
		}});
		foo_list.Add(new Foo(){InnerList = new List<Bar> {
			new Bar{Pro=false, Ind =4},
			new Bar{Pro=false, Ind =5},
			new Bar{Pro=false, Ind =6}
		}});
		
		var l = from x in foo_list
				where x.InnerList.Any(b => b.Pro)
				select x;
		l.Dump();
	}
	
	// Define other methods and classes here
	class Foo{
		public List<Bar> InnerList {get;set;}
		public Foo() {
			InnerList = new List<Bar>();
		}
	}
	
	class Bar {
		public bool Pro { get; set; }
		public int Ind { get; set; }
	}
