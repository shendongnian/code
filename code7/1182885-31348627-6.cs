    Regex RxCode = new Regex(@"&#(?:([0-9]+)|x([0-9a-fA-F]+));");
    string lineNew = RxCode.Replace(
    	line,
    	delegate( Match match )	{
    		return match.Groups[1].Success ? 
    			"" + (char)Convert.ToInt32( match.Groups[1].Value ) :
    			"" + (char)Int32.Parse( match.Groups[2].Value, System.Globalization.NumberStyles.HexNumber);
    	}
    );
