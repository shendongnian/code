    private static String ToHex(int value) {
      return (value & 0xFFFFFF).ToString("X6");
    }
    private static int FromHex(String value) {
      int v = Convert.ToInt32(value, 16);
      unchecked {
        return (v <= 0x7FFFFF) ? v : v | (int)0xFF000000;
      }
    }
     
