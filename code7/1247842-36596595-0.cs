    public static double ConvertToDoubleOrDefault(this string input, double def = 0.0) 
    {
      if (string.IsNullOrEmpty(str)) return def;
      double result;
      if (!double.TryParse(str, out result)) return def;
      return result; 
    }
    
    ....
    
    string test = "1234";
    string test2 = null;
    var d = test.ConvertToDoubleOrDefault(); // => 1234
    d = test2.ConvertToDoubleOrDefault(); // => 0.0
