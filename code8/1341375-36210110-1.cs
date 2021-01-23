    public class Product
    {
        private OffsetObj _offset = new OffsetObj();
 
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int OffsetYears
        {
            get { return _offset.Y; }
            set { _offset.Y = value; }
        }
        public int OffsetMonths
        {
            get { return _offset.M; }
            set { _offset.M = value; }
        }
        public int OffsetDays
        {
            get { return _offset.D; }
            set { _offset.D = value; }
        }
        public string Offset
        {
            get
            {
                return JsonConvert.SerializeObject(_offset);
            }
            set
            {
                _offset = JsonConvert.DeserializeObject<OffsetObj>(value);
            }
        }
        private class OffsetObj
        {
            public int Y { get; set; }
            public int M { get; set; }
            public int D { get; set; }
        }
    }
