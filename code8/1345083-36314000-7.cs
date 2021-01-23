      public static String Encrypt(String text) {
        if (String.IsNullOrEmpty(text))
          return text;
    
        int n = 689;
        int e = 41;
    
        return String.Concat(Encoding.ASCII.GetBytes(text)
          .Select(b => (char)BigInteger.ModPow(b, e, n)));
      }
    
      ...
    
      // and so you can encrypt as easy as
      textBox2.Text = Encrypt("indra");
