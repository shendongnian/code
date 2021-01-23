    private static String MaskedNumber(String source) {
      StringBuilder sb = new StringBuilder(source);
      const int skipLeft = 6;
      const int skipRight = 4;
      int left = -1;
      for (int i = 0, c = 0; i < sb.Length; ++i) {
        if (Char.IsDigit(sb[i])) {
          c += 1;
          if (c > skipLeft) {
            left = i;
            break;
          }
        }
      }
      for (int i = sb.Length - 1, c = 0; i >= left; --i)
        if (Char.IsDigit(sb[i])) {
          c += 1;
          if (c > skipRight)
            sb[i] = 'X';
        }
      return sb.ToString();
    }
    
    // Tests 
    
      // 3456-12XX-XXXX-1234
      Console.Write(MaskedNumber("3456-1234-3456-1234"));
      // 3456123XXXXX1234
      Console.Write(MaskedNumber("3456123434561234"));
