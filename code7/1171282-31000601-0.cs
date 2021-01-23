        private static String MaskedNumber(String source) {
          StringBuilder sb = new StringBuilder(source);
    
          for (int i = 0, c = 0; i < sb.Length && c < 6; ++i)
            if (Char.IsDigit(sb[i])) {
              sb[i] = 'X';
              c += 1;
            }
    
          for (int i = sb.Length - 1, c = 0; i >= 0 && c < 4; --i)
            if (Char.IsDigit(sb[i])) {
              sb[i] = 'X';
              c += 1;
            }
    
          return sb.ToString();
        }
    
    // Tests 
    
      // XXXX-XX34-3456-XXXX
      Console.Write(MaskedNumber("3456-1234-3456-1234"));
      // XXXXXX343456XXXX
      Console.Write(MaskedNumber("3456123434561234"));
