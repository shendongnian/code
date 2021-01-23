    public enum MyEnumA { A1, A2, A3 }
    partial class MyEnumExtensions
    {
    	public static string toString(this MyEnumA x)
    	{
    		//...
    		return x.ToString();
    	}
    	public static MyEnumA toMyEnumA(this string x)
    	{
    		//...
    		return (MyEnumA)Enum.Parse(typeof(MyEnumA), x);
    	}
    }
