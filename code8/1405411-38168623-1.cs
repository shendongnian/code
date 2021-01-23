      private static String MakeReport(float value) {
        return String.Join(" ", BitConverter
         .GetBytes(value)
         .Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
      }
    
    ...
    
      float f = 16777215;
    
      // Mantissa (first 3 bytes) is full of 1's except the last one bit
      // 11111111 11111111 01111111 01001011
      Console.Write(MakeReport(f)); 
    
      // Overflow! Presision loss
      // 00000000 00000000 10000000 01001011  
      Console.Write(MakeReport(f + 1)); 
    
      // Overflow! Presision loss
      // 00000000 00000000 10000000 01001011  
      Console.Write(MakeReport(f + 2)); 
      // Overflow! Presision loss
      // 00000100 00000000 10000000 01001011  
      Console.Write(MakeReport(f + 10)); 
