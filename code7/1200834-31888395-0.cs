    dump(System.Text.Encoding.UTF8.GetBytes(str1)) ;
    dump(System.Text.Encoding.UTF8.GetBytes(str2)) ;
    dump(System.Text.ASCIIEncoding.Default.GetBytes(str1)) ;
    dump(System.Text.ASCIIEncoding.Default.GetBytes(str2)) ;
    
    private void dump(byte[] bytes)
    { // HexaDecimal display
      console.writeln(BitConverter.ToString(bytes)) ;
    }
