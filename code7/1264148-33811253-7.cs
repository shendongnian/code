    public class Version_1 : VersionBase<WeirdDad>
    {
        public override WeirdDad Weird { get; set; } 
    }
    public class Version_2 : VersionBase<WeirdChild>
    {
        public string IdentityCode { get; set; }
        public override WeirdChild Weird { get; set; }
    }
