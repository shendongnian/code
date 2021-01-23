    public class MatchedSubstring
    {
      public int length { get; set; }
      public int offset { get; set; }
    }
    public class Term
    {
    public int offset { get; set; }
    public string value { get; set; }
    }
    public class Prediction
    {
    public string description { get; set; }
    public string id { get; set; }
    public List<MatchedSubstring> matched_substrings { get; set; }
    public string place_id { get; set; }
    public string reference { get; set; }
    public List<Term> terms { get; set; }
    public List<string> types { get; set; }
    }
    public class RootObject
    {
    public List<Prediction> predictions { get; set; }
    public string status { get; set; }
    }
