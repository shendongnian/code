    public class MyObjectList : List<MyObject>
    {
	    public MyObjectList(IEnumerable<MyObject> list)
	    	:base(list)
	    {	
	    }
    }
