    public class PersonSearch
    {
      public PersonSearch()
      {
      }
      public PersonSearch(string first, string middle, string last)
      {
        // format and remove leading or trailing white space as a result of nulls
        string name = string.Format("{0} {1} {2}", first, middle, last).Trim();
        // remove any internal extra white space if middle is null
        if (string.IsNullOrWhiteSpace(middle))
        {
          name = String.Join(" ", name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }
        Name = name;
      }
      public int PersonId { get; set; }
      public string Name { get; set; }
    }
