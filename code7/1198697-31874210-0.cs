    using OpcLabs.EasyOpc;
    using OpcLabs.EasyOpc.DataAccess;
    
    public class Demand
    {
    	private void frm_Load(System.Object sender, System.EventArgs e)
    	{
    		ReadPLCvalue();
    	}
    
    	private void ReadPLCvalue()
    	{
    		EasyDAClient objClient = new EasyDAClient();
    		object sValue = null;
    
    		try {
    			sValue = objClient.ReadItemValue(PLCServerMachineName, PLCServerID, PLCTagName);
    
    		} catch (OpcException ex) {
    		}
    
    		StoreToDB(sValue);
    	}
    
    	private void StoreToDB(object source)
    	{
    		//Database operations to store the value.
    	}
    	public Demand()
    	{
    		Load += frm_Load;
    	}
    }
