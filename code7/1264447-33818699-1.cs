    private string HexToString(string hex)
    {
        string result = "";
        
        while (hex.Length > 0) 
        {
            result += Convert.ToChar(Convert.ToUInt32(hex.Substring(0, 2), 16));
            hex = hex.Substring(2); // no need to specify the end
        }
        return result;
    }
   
