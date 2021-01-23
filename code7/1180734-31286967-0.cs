    public static string VBColorToHexConverter(string vbColor) 
    {
      string hexValue;
      string r = "", g = "", b = "";
      char[] vbValue = vbColor.ToCharArray();
      for (int i = 0; i < vbValue.Length; i++) 
      {
        r = vbValue[6].ToString() + vbValue[7].ToString();
        g = vbValue[4].ToString() + vbValue[5].ToString();
        b = vbValue[2].ToString() + vbValue[3].ToString();
      }
      hexValue = "#" + r + g + b;
      return hexValue;
    }
