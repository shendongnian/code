    public static String IsCarPlateValid(String value) {
      // we don't accept null or empty strings
      if (String.IsNullOrEmpty(value))
        return false;
    
      // should contain exactly 11 characters
      //  letter{1}, space {2}, digit{4}, space{1}, letter{3}  
      //  1 + 2 + 4 + 1 + 3 == 11
      if (value.Length != 11)
        return false;
      
      // First character should be in ['A'..'Z'] range;
      // if it either less than 'A' or bigger than 'Z', car plate is wrong
      if ((value[0] < 'A') || (value[0] > 'Z'))
        return false;
      //TODO: it's your homework, implement the rest
    
      // All tests passed
      return true;
    }
