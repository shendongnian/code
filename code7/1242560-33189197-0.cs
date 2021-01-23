    public class Cell
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public Cell(){}
        public Cell(KeyValuePair<string, object> kvp)
        {
            Name = kvp.Key;
            Value = kvp.Value;
        }
    }
    public class Row : List<Cell>
    {
        public Row(){}
        public Row(IEnumerable<Cell> cells)
            : base(cells){}        
    }
    public class Rows : List<Row>
    {
        public Rows(){}
        public Rows(IEnumerable<Row> rows )
            :base(rows){}
    }
