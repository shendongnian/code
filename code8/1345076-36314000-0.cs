      public void enkrip() {
         string text = "indra";
         byte[] asciiBytes = Encoding.ASCII.GetBytes(text);
         // "iùŢĕ" 
         // the last symbol has "28" code and being a command one has not being displayed
         textBox2.Text = String.Concat(asciiBytes   
           .Select(b => (char)BigInteger.ModPow(b, e, n)));
      }
