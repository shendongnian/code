    public interface IModem
    {
    	string GetName();
    }
    
    class HuaweiModem : IModem
    {
    	public string Name { get; set; }
    
    	public string GetName()
    	{
    		return Name;
    	}
    }
    
    interface IModemReader
    {
    	List<IModem> DetectModems();
    }
    
    public class WmiModemReader : IModemReader
    {
    	public List<IModem> DetectModems()
    	{
    		List<IModem> result = new List<IModem>();
    		var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_POTSModem");
    		foreach (var queryObj in searcher.Get())
    		{
    			if ((string)queryObj["Status"] == "OK")
    			{
    				IModem modem = new HuaweiModem()
    				{
    					Name = queryObj["AttachedTo"] + " - " + Convert.ToString(queryObj["Description"])
    				};
    				result.Add(modem);
    			}
    		}
    		return result;
    	}
    }
