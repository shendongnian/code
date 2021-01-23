    public class PeopleVM
    {
      public int GroupSize { get; set; }
      public IEnumerable<IGrouping<int, Person>> Groups  { get; set; }
    }
