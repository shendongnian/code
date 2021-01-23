    // Elsewhere
    class SortFields {
      public string Field1 { get; set; }
      public string Field2 { get; set; }
      public DateTime StartDate { get; set; }
      public static SortFields SplitInput(string input) {
        // Factory... Implement split/parse logic
      }
    }
    and then
    from r in this.CurrentTemplateInfos
    where r.EffectiveEnd == null
    let fields = SortField.SplitInput(r.Description)
    // This means sort by Field1, then Field2 and then StartDate
    // and the default in each criterion is ascending unless you
    // specify descending keyword.
    orderby fields.Field1, fields.Field2, fields.StartDate descending 
    select r
