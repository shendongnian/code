    //Your class
    public class MyClass 
    {
        public class CustomColor 
        {
            public int h;
            public int s;
            public int v;
        }
    
        public string[] ConvertColors(List<CustomColor> colors)
        {
            return new string[]{"1"};
        }
    }
    
    //Usage
    MyClass mc = new MyClass();
    	MyClass.CustomColor cc = new MyClass.CustomColor();
    	
    	Type t = mc.GetType();
    	MethodInfo mi = t.GetMethod("ConvertColors");
    	List<MyClass.CustomColor> lst = new List<MyClass.CustomColor>
    	{	
    		new MyClass.CustomColor(),
    		new MyClass.CustomColor()
    	};
    	var x = (string[])mi.Invoke(mc,new object[]{lst});
    	Console.WriteLine (x.Count());
