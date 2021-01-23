    [Guid("0B201484-E388-45eb-9AB8-A6AE1E197AAB")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IThingy
    {
    	[DispId(1)]
    	int DoThing1(string name, int age);
    
    	[DispId(2)]
    	string DoThing2(int id);
    
    	[DispId(3)]
    	bool DoThing3(string address);
    }
