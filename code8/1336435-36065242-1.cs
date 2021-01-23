    class Person
    {
    	public string Name {get; set;}
    	public int Instance {get; set;}
    }
	Person p1 = new Person {Name ="C"};
	Person p2 = new Person {Name ="B"};
	Person p3 = new Person {Name ="A"};
	Person p4 = new Person {Name ="C"};
	Person p5 = new Person {Name ="C"};
	Person p6 = new Person {Name ="B"};
	
	var persons = new List<Person>{p1, p2, p3, p4, p5, p6};
	
	var result = from p in persons
				 group p by p.Name into g orderby g.Key
				 from gr in g.Select((x,i) => new {Value = x, Index = i})
				 select gr;
	result.Aggregate(0, (_, next) => {next.Value.Instance = next.Index; return 0;});
	var list = result.Select(gr => gr.Value);	
