    public class Foo
    {
    	public int Id { get; set; }
    	public string  Name { get; set; }
    
    	public override bool Equals(object obj)
    	{	
    		return this.Id==((Foo)obj).Id
    			&& this.Name==((Foo)obj).Name;
    	}
    	public override int GetHashCode()
    	{
    		return Id.GetHashCode() + Name.ToLower().GetHashCode();
    	}
    }
    
    public class Bar
    {
    	public int SomeOtherId { get; set; }
    	public string SomeOtherName { get; set; }
    
    	public override bool Equals(object obj)
    	{
    		return this.SomeOtherId == ((Bar)obj).SomeOtherId
    			&& this.SomeOtherName == ((Bar)obj).SomeOtherName;
    	}
    	public override int GetHashCode()
    	{
    		return SomeOtherId.GetHashCode() + SomeOtherName.ToLower().GetHashCode();
    	}
    }
    
    //Usage
    var dict = new Dictionary<KeyValuePair<Foo, Bar>, float>();
    dict.Add(new KeyValuePair<Foo, Bar>(new Foo { Id = 1, Name = "Foo" }, new Bar {SomeOtherId = 1, SomeOtherName = "Bar"}), 10);
    	
    Console.WriteLine(dict[new KeyValuePair<Foo, Bar>(new Foo { Id = 1, Name = "Foo" }, new Bar {SomeOtherId = 1, SomeOtherName = "Bar"})]);
