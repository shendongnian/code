    public static byte[] GetBinaryFromHexaString (string hexa)
    {
    	byte[] data = null;
    	List<byte> bList = new List<byte>();
    	try {
    		for (int i = 2; i < hexa.Length - 1; i+=2) {
    			string hStr = hexa.Substring(i, 2);
    			byte b = byte.Parse(hStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
    			bList.Add (b);
    		}
    		data = bList.ToArray();
    	}
    	catch {}
    	return data;
    }
    
    var sqlBytes = new System.Data.SqlTypes.SqlBytes (GetBinaryFromHexaString(a));
