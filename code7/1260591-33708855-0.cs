    using System;
    using System.Text.RegularExpressions;
    using System.Linq;
    public class Test
    {
    	public static void Main()
    	{
    		var str  = "some text, here could be additional text, CN=John Doe + SERIALNUMBER=XID:1234-2002-2-123413342134, O=No, C=EN";
    		var res = Regex.Match(str, @"\bXID:[0-9-]+");
    		if (res.Success)
    			Console.WriteLine(res.Value);
    	}
    }
