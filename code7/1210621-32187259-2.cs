    public static class SharedData
    {
    	public static string Meta { get; private set; }
    	public static int Value { get; private set; }
    	
    	public static void SetData(string meta, int value)
    	{
    		Meta = meta;
    		Value = value;
    	}
    }
    public class DerivedData
    {
    	public string Test
    	{
    		get { return string.Format("Shared meta = {0}, Shared Value = {1}", SharedData.Meta, SharedData.Value); }
    	}
    }
