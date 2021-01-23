	internal interface InterfaceA
	{
		string Data {get; }
	}
	public interface InterfaceB
	{
		OpaqueToken DoStuff();
	}
	public interface InterfaceC
	{
		IEnumerable<OpaqueToken> GetStuffThatHaveBeenDone();
	}
    public sealed class OpaqueToken
    {
        internal OpaqueToken() {} 
        internal InterfaceA A { get; set; }
    }
