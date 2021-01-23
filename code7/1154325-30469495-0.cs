    class Test1{
    	public int t1 {get; set;}
    	public string t2  {get;  set;}
    	public Type t3  {get;  set;}
    	public bool t4  {get;  set;}
    	public double t5  {get;  set;}
    	public float t6 {get;  set;}
    	public double field;
    }
    
    void Main()
    {
    	PrintProps(new Test1());
    	PrintProps(new System.Drawing.Point());
    
    }
    
    private static void PrintProps(object o){
    	Console.WriteLine("Begin: " + o.GetType().FullName);
    	var t = o.GetType();
    	var props = t.GetProperties(BindingFlags.Public | 
                                        BindingFlags.Instance); // you can do same with GetFields();
    	foreach(var p in props){
    		Console.WriteLine(string.Format("{0} = {1}", p.Name,p.PropertyType == typeof(double)));
    	}	
    	Console.WriteLine("End");
    }
