      public void enkrip() {
         string text = "indra";
         byte[] asciiBytes = Encoding.ASCII.GetBytes(text);
         // 69, 0f9, 162, 115, 1c
         textBox2.Text = String.Join(", ", asciiBytes   
           .Select(b => BigInteger.ModPow(b, e, n).ToString("x2")));
      }
