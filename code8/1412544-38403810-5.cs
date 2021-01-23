    public class mComputedProp
    {
        public string feedbackSource { get; set; }
        public string status { get; set; }
        public string feedbackType { get; set; }
    }
    public class mcomputedprops
        {
            [JsonProperty("parameters")]
            public List<mComputedProp> mprops = new List<mComputedProp>();
        }
