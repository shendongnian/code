    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var xDoc = XDocument.Parse(xmlString);
    		var status = xDoc.Descendants("optinStatus").Single();
    		Console.WriteLine(status.Value);
    	}
    	
    	private static string xmlString = @"
    	
    	
    <response op=""getcustomerinfo"" status=""200"" message=""ok"" version=""1.0"">
      <customer>
        <totalMsg>3</totalMsg>
        <custId>9008281</custId>
        <custName></custName>
        <timestamp>2015-04-30 16:17:19</timestamp>
        <optinStatus>3</optinStatus>
        <custMobile>6185312349</custMobile>
        <subacct>1st Choice Courier</subacct>
      </customer>
    </response>	
    	
    	
    	";
    }
