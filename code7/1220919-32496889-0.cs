	void Main()
	{
		JsonConvert.DeserializeObject<A>(@"{
			property: ""apweiojfwoeif"",
			nested: {
				prop1: ""wpeifwjefoiwj"",
				prop2: ""9ghps89e4aupw3r""
			}
		}").Dump();
		JsonConvert.DeserializeObject<A>(@"{
			property: ""apweiojfwoeif"",
			nested: """"
		}").Dump();
	}
	
	// Define other methods and classes here
	class A {
		public string Property {get;set;}
		public B Nested {get;set;}
	}
	
	class B {
		public string Prop1 {get;set;}
		public string Prop2 {get;set;}
	}
