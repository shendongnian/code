    public class MyRow : IRow<string, MyCell>
    {
        public string RowHeader { get; set; }
        public IList<MyCell> Zellen { get; set; }
    }
