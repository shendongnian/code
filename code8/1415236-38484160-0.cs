    void Main()
    {
    	List<A> listA1 = new List<A> {
    	   new A { Id=1, ModifiedDate=new DateTime(2016,1,1), Type="A"},
    	   new A { Id=2, ModifiedDate=new DateTime(2016,1,2), Type="A"},
    	   new A { Id=3, ModifiedDate=new DateTime(2016,1,3), Type="A"},
    	   new A { Id=4, ModifiedDate=new DateTime(2016,1,4), Type="A"},
    	};
    	List<A> listA2 = new List<A> {
    	   new A { Id=1, ModifiedDate=new DateTime(2016,1,1), Type="A"},
    	   new A { Id=2, ModifiedDate=new DateTime(2016,1,2), Type="A"},
    	   new A { Id=3, ModifiedDate=new DateTime(2016,1,3), Type="A"},
    	   new A { Id=4, ModifiedDate=new DateTime(2016,1,5), Type="A"},
    	   new A { Id=5, ModifiedDate=new DateTime(2016,1,6), Type="A"},
    	   new A { Id=6, ModifiedDate=new DateTime(2016,1,7), Type="A"},
    	};
    
    	var cmp = new AEqualityComparer();
    	var result = listA1.Except(listA2, cmp);
    	
    	foreach (var item in result)
    	{
    		Console.WriteLine("Id:{0}, Date:{1}",item.Id, item.ModifiedDate);
    	}
    }
    
    public class A
    {
    	public int Id { get; set; }
    	public DateTime ModifiedDate { get; set; }
    	public string Type { get; set; }
    }
    
    public class AEqualityComparer : IEqualityComparer<A>
    {
    	public bool Equals(A x, A y)
    	{
    		return x.Id == y.Id && x.ModifiedDate == y.ModifiedDate;
    	}
    
    	public int GetHashCode(A obj)
    	{
    		return obj.ToString().GetHashCode();
    	}
    }
