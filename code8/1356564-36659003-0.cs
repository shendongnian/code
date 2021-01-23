	string foo = "6F6F6F6F6F";
	string[] arrXmlValues = new String[] { "00B50578", "00A41434", "00B50578" };
		
	var index = 0;
	foreach (string r in arrXmlValues)
	{
		var arr = r.ToCharArray();	
        
        // magic is here
		for(var j = 2; j < arr.Length && index < foo.Length; j++) arr[j] = foo[index++];
		Console.WriteLine("Original value was : {0}", r);
		Console.WriteLine("New value is : " + new String(arr));
	}
