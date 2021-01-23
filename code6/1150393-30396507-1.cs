    private static String Hex2Oct(String value) {
      // Assuming that given value is short enough to be represented as Int64
      return Convert.ToString(Convert.ToInt64(value, 16), 8);
    }
    ...
    Console.Write(Hex2Oct("FFF0FFFFFF")); // 17776077777777
