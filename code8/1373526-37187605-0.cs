    public IEnumerable<TitleNew> TitleOption =
    new List<TitleNew>
    {
        new TitleNew {Id = 0, Value = "Mr."},
        new TitleNew {Id = 1, Value = "Ms."}
    };
    public class TitleNew
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
    public string Title { get; set; }
