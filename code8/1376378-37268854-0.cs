    public Student GetTopper(IEnumerable<Student> value) {
      if (null == value)
        throw new ArgumentNullException("value");
    
      boolean first = true;
      Student result = null;
      double maxValue = double.NegativeInfinity;
    
      foreach (var item in value) {
        if (null == item)
          continue;
    
        // there's no need to divide by 3, providing that M1, M2, M3
        // are small enough not to trigger integer overflow
        if (first || item.M1 + item.M2 + item.M3 > maxValue) {
          first = false;
          maxValue = item.M1 + item.M2 + item.M3;
          result = item;   
        }
      }
    
      return result; 
    }
