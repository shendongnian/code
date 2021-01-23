    public class myClass
    {
    	public string myProp { get; set; }
    }
	var a = new myClass();
	var result = a.nameof(b => b.myProp);
