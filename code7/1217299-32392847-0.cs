        public static IEnumerable<String> SplitByLength(String value, int size, Char padding = ' ') {
          if (String.IsNullOrEmpty(value)) 
            yield break; // or throw an exception or return new String(padding, size);
    
          if (size <= 0)
            throw new ArgumentOutOfRangeException("size", "size must be a positive value");
    
          // full chunks with "size" length
          for (int i = 0; i < value.Length / size; ++i)
            yield return value.Substring(i * size, size);
    
          // the last chunk (if it exists) should be padded
          if (value.Length % size > 0) {
            String chunk = value.Substring(value.Length / size * size);
    
            yield return new String(padding, (size - chunk.Length) / 2) + chunk + new String(padding, (size - chunk.Length + 1) / 2);
          }
        }
    ...
    
    String source = "27 Calle, Col. Ciudad Nueva, San Pedro Sula, Cortes";
    
    // I've set padding to '*' in order to show it
    // 27 Calle, 
    // Col. Ciuda
    // d Nueva, S
    // an Pedro S
    // ula, Corte
    // ****s*****
    Console.Write(String.Join(Environment.NewLine,
      SplitByLength(source, 10, '*')));
