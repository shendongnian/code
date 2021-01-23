    public class From
    {
        public bool Active { get; set; }
        public string Name { get; set; }
    }
    public class To
    {
        public string DestinationName { get; set; }
    }
    static void Main(string[] args)
    {
        Mapper.CreateMap<From, To>()
            .ForMember(to => to.DestinationName, opt => opt.MapFrom(from => from.Active ? from.Name : (string)null));
        WriteMappedFrom(new From() {Active = true, Name = "ActiveFrom"});
        WriteMappedFrom(new From() {Active = false, Name = "InactiveFrom"});
    }
    static void WriteMappedFrom(From from)
    {
        Console.WriteLine("Mapping from " + (from.Active ? "active" : "inactive") + " " + from.Name);
        var to = Mapper.Map<To>(from);
        Console.WriteLine("To -> " + (to.DestinationName ?? "null"));
    }
