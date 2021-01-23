    public class MyCell : ICell<string>
    {
        public string Background { get; set; }
        public string Content { get; set; }
        public string Foreground { get; set; }
    }
    public class MyRow: IRow<string,MyCell>
    {
        public string RowHeader { get; set; }
        public IList<MyCell> Zellen { get; set; }
    }
