	public class AuthorAttributes
    {
        private readonly Dictionary<Int32, Int32> _paper = new Dictionary<Int32, Int32>();
        public Int32 this[Int32 key]
        {
            // returns value if exists
            get { return _paper[key]; }
            // updates if exists, adds if doesn't exist
            set { _paper[key] = value; }
        }
        public int _CoAuthor_ID { get; set; }
        public int _Venue_ID { get; set; }
    }
