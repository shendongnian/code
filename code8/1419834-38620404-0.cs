    public static string sha256_hash(string sValue) {
      StringBuilder oResHash = new StringBuilder();
    
      using (SHA256 oHash = SHA256Managed.Create()) {
        Encoding oEnc = Encoding.UTF8;
        byte[] baResult = oHash.ComputeHash(oEnc.GetBytes(sValue));
    
        foreach (byte b in baResult)
          oResHash.Append(b.ToString("x2"));
      }
    
      return oResHash.ToString();
    }
