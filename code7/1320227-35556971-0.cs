    public class Foo
    {
        public ISet<DescriptionInfo> Descriptions { get; set; }
    }
    public class DescriptionInfo
    {
        public int LanguageID { get; set; }
        public string Value { get; set; }
        public override bool Equals(object obj)
        {
            var anotherInfo = (DescriptionInfo)obj;
            return anotherInfo.LanguageID == LanguageID;
        }
        public override int GetHashCode()
        {
            return LanguageID;
        }
    }
