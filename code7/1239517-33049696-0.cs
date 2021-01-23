    public class MainModel
    {
      public IEnumerable<NestedModel> Issues { get; set; }
    }
    public class NestedModel
    {
      public bool IsChecked { get; set; }
      public string Label { get; set; }
    }
