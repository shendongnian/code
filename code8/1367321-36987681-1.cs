    public class Object1
    {
    	public Object1(Object2 object2)
    	{
        	this.object2=object2;
    	}
    
    	public Object2 object2 {get;set;}
    
    	public string PropertyOfObject1 {get;set;}
    }
    
    
    public class Object2
    {
    	public string PropertyOfObject2 {get;set;}
    }
    
    
    List<Object1> objectList1 = new List<Object1>();
    
    Object2 o2 = new Object2();
    Object1 item1 = new Object1(o2);
    objectList1.Add(item1);
