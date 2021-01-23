      public void enkrip() {
         string text = "indra";
         byte[] asciiBytes = Encoding.ASCII.GetBytes(text);
         // 0069, 00f9, 0162, 0115, 001c
         textBox2.Text = String.Join(", ", asciiBytes   
           .Select(b => BigInteger.ModPow(b, e, n).ToString("x4")));
      }
