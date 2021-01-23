    public class MyViewModel
    {
        public string SerializedProperty { get; set; }
        [IgnoreDataMember]
        public string IgnoredProperty { get; set; }
    }
