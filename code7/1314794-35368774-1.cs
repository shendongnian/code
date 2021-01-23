    public class Foo
    {	
    	public void DoFoo
    	{
    		 bool isDebug = false;
    		 var bar = new Bar();
    		 bar.DoBar(isDebug)
    	}	
    }
    
    public class Bar
    {	
    	public void DoBar(bool isDebug)
    	{
    		if(isDebug)
    		{
    			// this is debug set
    		}
    		else
    		{
    			// this is something else
    		}
    	}	
    }
