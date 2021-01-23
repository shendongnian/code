    public class Rule
    {
      public string Id { get; set; }
      public string Field { get; set; }
      public string Type { get; set; }
      public string Input { get; set; }
      public string Operator { get; set; }
      public string Value { get; set; }
      public string Condition { get; set; }
      public IEnumerable<Rule> Rules { get; set; }
    }
