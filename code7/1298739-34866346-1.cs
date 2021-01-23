    public string getPhoneNumber(string phone) {
       string result = System.Text.RegularExpressions.Regex.Replace(phone, @"[^0-9]+", string.Empty);
       if (result.Length <= 10) {
           return Double.Parse(result).ToString("###-###-####");
       } else {
           return Double.Parse(result.Substring(0,10)).ToString("###-###-####") + 
           "x " + result.Substring(10, result.Length-10);
       }
    }
