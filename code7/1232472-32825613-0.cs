    public class IndexDataRowPair
    {
        public int Index {get;set;}
        public DataRow Row {get;set;}
        // or, just the values you intend to use
        // public string InputValue {get;set;}
        // public string ExpressionValue {get;set;}
    }
     
    ...
    // generic Select<TIn, Tin, TResult> parameters will be inferred:= 
    // Select<DataRow, int, IndexDataRowPair> 
    dt.Select((row,idx) => new IndexDataRowPair() { Index = idx, Row = row });
