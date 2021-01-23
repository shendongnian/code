    public void SetText(params int[] xs) { }
    
    public class Impinj
    {
    	public class OctaneSdk
    	{
    		public class TagData { }
    		public class ImpinjTimestamp { }
    	}
    }
    
    public class ImpinjReader { }
    
    public class TagReport : List<Tag> { }
    
    public class Tag
    {
    	public ushort AntennaPortNumber;
    	public Impinj.OctaneSdk.TagData Epc;
    	public Impinj.OctaneSdk.ImpinjTimestamp LastSeenTime;
    }
