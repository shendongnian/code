    // Your Model
    public class Model_Test
        {
            public string Prop1 { get; set; }            
            public string Prop2 { get; set; }
            public bool[] Prop3 { get; set; }
        }
    
    //Usage
    List<Model_Test> lst = new List<Model_Test>(){
    		new Model_Test{Prop1="Foo", Prop2="Bar",Prop3 = new bool[]{true,false,true}},
    		new Model_Test{Prop1="Foo2", Prop2="Bar2",Prop3 = new bool[]{true,false,false}},
    		new Model_Test{Prop1="Foo3", Prop2="Bar3",Prop3 = new bool[]{true,false,true}},
    	};
    	
        // Query Expression
    	var result = from element in lst
    				where element.Prop3[2] == true
    				select new {Name = element.Prop1, Value = element.Prop2};
    	
		// Lambda Expression	
    	var result2 = lst.Where(x=>x.Prop3[2]==true).Select(x=> new {Name=x.Prop1, Value = x.Prop2});
