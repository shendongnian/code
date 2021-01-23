    public enum MyEnumB { B1, B2, B3 }
    partial class MyEnumExtensions
    {
    	public static string toString(this MyEnumB x)
    	{
    		//...
    		return x.ToString();
    	}
    	public static MyEnumB toMyEnumB(this string x)
    	{
    		//...
    		return (MyEnumB)Enum.Parse(typeof(MyEnumB), x);
    	}
    }
