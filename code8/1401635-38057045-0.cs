    string binary = "0000001010000000";
    StringBuilder hexvalue= new StringBuilder(binary.Length / 8 + 1);           
    int Len = binary.Length % 8;
    if (Len != 0)
    {               
         binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
    }
    for (int i = 0; i < binary.Length; i += 8)
    {
         string Bits = binary.Substring(i, 8);
         hexvalue.AppendFormat("{0:X2}", Convert.ToByte(Bits , 2));
    }
    binary =  hexvalue.ToString();          
