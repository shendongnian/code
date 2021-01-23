    public class Src1
    {
        public string Name { get; set; }
        public int? Age { get; set; }
    }
    public class Dest1
    {
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
    }
    Mapper.CreateMap<Src1, Dest1>();
    Mapper.AssertConfigurationIsValid();
    var s = new Src1 {Name = "aaa", Age = null};
    var d = Mapper.Map<Src1, Dest1>(s);
