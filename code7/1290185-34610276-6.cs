    public class Report: IReport
    {
        public ICollection<IColumn> Columns { get; set; }
        public Report() { Columns = new List<IColumn>(); }
    }
    public class Column: IColumn
    {
        public ICollection<Value> Values { get; set; }
        public Column() { Values = new List<Value>(); }
    }
