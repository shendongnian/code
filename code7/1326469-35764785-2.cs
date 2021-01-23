    public class Detail
    {
        public string address { get; set; }
        public string type { get; set; }
        public override string ToString() { return this.ToStringWithReflection(); }
    }
    public class Family
    {
        public string myGuardName { get; set; }
        public List<Detail> details { get; set; }
        public override string ToString() { return this.ToStringWithReflection(); }
    }
    public class Member
    {
        public string type { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public Family Family { get; set; }
        public override string ToString() { return this.ToStringWithReflection(); }
    }
    public class RootObject
    {
        public string Sex { get; set; }
        public string category { get; set; }
        public int ID { get; set; }
        public string created { get; set; }
        public string Tag { get; set; }
        public List<Member> members { get; set; }
        public override string ToString() { return this.ToStringWithReflection(); }
    }
