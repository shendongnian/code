    public class RcptDetail
    {
        public string RECORD_ID { get; set; }
        /* ... */
    }
    public class RcptHeader
    {
        public string RECORD_ID { get; set; }
        /* ... */
        public RcptDetail RCPT_DETAIL { get; set; }
    }
