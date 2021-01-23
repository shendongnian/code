    struct Column
    {
        public string title;
        public List<object> col;
    }
    
    var signals = new List<Column>();
    signals.Add(new Column {title = "stringCol", col = new List<string>() });
    signals.Add(new Column {title = "doubleCol", col = new List<double>() });
