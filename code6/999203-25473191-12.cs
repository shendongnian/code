    [JsonObject(MemberSerialization.OptIn)]
    public class Points
    {
        public XYZ bboxmin { get; set; }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [JsonProperty(PropertyName = "bboxmin")]
        public XYZProxy bboxminProxy
        {
            get
            {
                return bboxmin.ToXYZProxy();
            }
            set
            {
                bboxmin = value.ToXYZ();
            }
        }
    }
