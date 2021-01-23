    static Dictionary<string, int> convert(string s)
        {
            var t = new Dictionary<string, int>();
            t.Add(s.Split('-')[0], System.Convert.ToInt32(s.Split('-')[1]));
            return t;
        }
  
    var t = "\"test\"-123,\"test\"-123";
    var d = t.Split(',').Select(convert);
