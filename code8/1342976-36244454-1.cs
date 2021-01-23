    class RangeListMetaData
    {
        private readonly List<RangeMetaData> _rangeList;
        public RangeListMetaData()
        {
            _rangeList = new List<RangeMetaData>();
        }
        public void Add (RangeMetaData rangeMetaData)
        {
            _rangeList.Add(rangeMetaData);
        }
    }
    class RangeMetaData
    {
        public RangeMetaData(xl.Range range)
        {
            this.Range = range;
        }
        public RangeMetaData(xl.Range range, object value) : this(range)
        {
            this.RangeValue = value;
        }
        public xl.Range Range { get; private set; }
        public object RangeValue { get; set; }
    }
    class TestRangeMetaData
    {
        void Test()
        {
            var rangeListMetaData = new RangeListMetaData();
            // storing part
            RangeMetaData range = new RangeMetaData([Your excel Cells], [You Value]);
            rangeListMetaData.Add(range);
            // Retrieve Part
            rangeListMetaData.FindByRange(...);
            rangeListMetaData.FindByValue(...);
            rangeListMetaData.FindBySomethingElse(...);
        }
    }
