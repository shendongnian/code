    void Main()
    {
        var query1 = Categories.Select(s => new MyObject { A = s.id, B = s.name });
    
        var query2 = Cities.Select(s =>  new MyObject { A = s.id, B = s.city_name, C = s.location });
    
        var result = query1.ToList().Concat(query2);
    	result.Dump();
    }
    public class MyObject
    {
    	public int A {get;set;}
    	public string B {get;set;}
    	public object C {get;set;}
    }
