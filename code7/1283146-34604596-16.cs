    public static bool IsFloatOrDoubleByDot(string str) { //another criterion for float, giving "f" in the last part?
			if (string.IsNullOrWhiteSpace(str))
				return false;
			int dotCounter = 0;
			for (int i = str[0] == '-' ? 1 : 0; i < str.Length; i++) { //Check if it is float
        if (!(char.IsDigit(str, i)) && (str[i] != '.'))
          return false;
        else if (str[i] == '.')
          ++dotCounter; //Increase the dotCounter whenever dot is found
        if (dotCounter > 1) //If there is more than one dot for whatever reason, return error
          return false;
      }
      return dotCounter == 0 || dotCounter == 1 && str.Length > 1;
    }
    public static bool IsDigitsOnly(string str) {
      foreach (char c in str)
        if (c < '0' || c > '9')
          return false;      
      return str.Length >= 1; //there must be at least one character here to continue
    }
    public static bool IsInt(string str) { //is not designed to handle null input or empty string
			if (string.IsNullOrWhiteSpace(str))
				return false;			
      return str[0] == '-' && str.Length > 1 ? IsDigitsOnly(str.Substring(1)) : IsDigitsOnly(str);
    }
