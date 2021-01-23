    static int Map(char c)
    {
    	return Int32.Parse (c.ToString(), System.Globalization.NumberStyles.HexNumber);
    }
	var max = "5623ADCB".Select (Map).Max ();
