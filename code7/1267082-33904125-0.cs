    public class JsonAggregates
    {
        public List<Aggregate> Aggregates { get; set; }
        public string GroupBy { get; set; }
    }
    public class Aggregate
    {
        public string ColumnName {get; set;}
        public string AggregateFunction {get; set;}
    }
