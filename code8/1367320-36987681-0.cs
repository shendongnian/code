    public class objectList1
    {
    	public objectList1(Object2 object2)
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
    
    
    List<objectList1> list = new List<objectList1>();
    
    Object2 o2 = new Object2();
    objectList1 item1 = new objectList1(o2);
    list.Add(item1);
