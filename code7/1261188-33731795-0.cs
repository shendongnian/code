    public class Program
    {
    	static void Main()
    	{
    		QMain obj = new QMain();
    		object a = obj.objQ("A");
    
    		//FYI the below commended out is not possible...
    		//ClsA.staticField is but that is not the instance you created.
    		//------------
    		//a.staticField //<--- not possible
    		//------------
    		
    		var someA = a as ClsA; //<--- attempts to case it as ClsA
    		var someB = a as ClsB; //<--- attempts to case it as ClsB
    		if (someA != null) //check if the cast was successful
    		{
    			var var1 = someA.StrMessage;
    		}
    		else if (someB != null)
    		{
    			//...
    		}
    	}
    }
    
    public class QMain
    {
    	public object objQ(string str)
    	{
    		if (str.ToUpper() == "A")
    		{
    			ClsA objA = new ClsA();
    			return objA;
    		}
    		else if (str.ToUpper() == "B")
    		{
    			ClsB objB = new ClsB();
    			return objB;
    		}
    		else
    			return "";
    	}
    
    }
    
    public class ClsA
    {
    	public string StrMessage { get; private set; }
    	public static string StaticField;
    	public bool CantAccessThisFn(string str)
    	{
    		return true;
    	}
    }
    
    public class ClsB
    {
    	public string StrMessageMyC { get; private set; }
    	public static string StaticFieldMyC;
    	public bool CantAccessThisFnMyC(string str)
    	{
    		return true;
    	}
    }
