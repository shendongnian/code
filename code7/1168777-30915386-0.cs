    public string function HexConvert(string InputText)
    {
    	StringBuilder sb=new StringBuilder();
    	char[] lettercollection = InputText.ToCharArray();
    	foreach (char letter in lettercollection)
    	{
    		int integerValue = Convert.ToInt32(letter); //convert to integer
    		string hexCode = String.Format("{0:X}", integerValue); //hex generation
    		sb.append(hexCode); 
    	}
    	return sb.ToString(); //your output
    }
