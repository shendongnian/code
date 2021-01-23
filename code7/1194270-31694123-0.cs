    public static string StringToBinary(string ip)
    {
    
     StringBuilder sb = new StringBuilder();
     
     foreach (char c in ip.ToCharArray())
     {
    
     sb.Append(Convert.ToString(c, 2).PadLeft(8,'0'));
    
     }
    
     return sb.ToString();
    
    }
    
    This Method Is used to convert binary to string  : 
    
    public static string BinaryToString(string ip)
    {
    
     List<Byte> byteList = new List<Byte>();
     
     for (int i = 0; i < ip.Length; i += 8)
     {
    
     byteList.Add(Convert.ToByte(ip.Substring(i, 8), 2));
    
     }
     
     return Encoding.ASCII.GetString(byteList.ToArray());
    
    }
