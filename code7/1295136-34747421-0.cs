    void Main()
    {
    	Console.WriteLine(SType.Active.Value);
    	Console.WriteLine(SType.Active.List);
    }
    
    [Flags]
    public enum SState : int
    {
        ManuelPassive = 2501601,
        AutoPassive = 2501602,
        ManuelActive = 2501610,
        AutoActive = 2501611,
    }
    
    public sealed class SType
    {
    	public static readonly SType Active = new SType(new List<SState>() { SState.AutoActive, SState.ManuelActive });
    	
    	public static readonly SType Passive = new SType(new List<SState>() { SState.AutoPassive, SState.ManuelPassive });
    
    	private SType (List<SState> values)
    	{
    		this.Value = (int)values.Aggregate((current, next) => current | next);
    		this.List = values;
    	}
    
    	public int Value { get; private set; }
    	
    	public List<SState> List { get; private set; }
    }
