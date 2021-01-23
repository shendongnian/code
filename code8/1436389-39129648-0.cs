    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ObjectDTO, Object>()
                    .ForMember(dest => dest.Number, opt => opt.Condition(src => src.Number.HasValue))
                    .ForMember(dest => dest.LastUpdateDate, opt => opt.Condition(src => src.LastUpdateDate.HasValue));
            });
            
            Mapper.AssertConfigurationIsValid();
            var source = new ObjectDTO { LastUpdateDate = DateTime.Now };
            var destination = new Object { Number = 10, LastUpdateDate = DateTime.Now.AddDays(-10) };
            var result = Mapper.Map(source, destination);
        }
    }
    public class ObjectDTO
    {
        public int? Number { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        
    }
    public class Object
    {
        public int? Number { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
