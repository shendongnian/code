    class Foo
    {
        Lazy<List<Row>> _rows;
        public Foo()
        {
            _rows = new Lazy(() => new List<Row>());
        }
        public List<Row> Rows
        {
            get { return _rows.Value; }
        }
    }
