      public void enkrip() {
         string text = "indra";
         byte[] asciiBytes = Encoding.ASCII.GetBytes(text);
         // "iùŢĕ" 
         textBox2.Text = String.Concat(asciiBytes   
           .Select(b => (char)BigInteger.ModPow(b, e, n)));
      }
