    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<SourceExamModel, DestinationExamModel>()
                    .ForMember(dest => dest.DestSections, c => c.MapFrom(src => src.Sections))
            );
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            var source = new SourceExamModel
            {
                ExamId = 1,
                Sections = new List<SectionModel> { new SectionModel { SectionId = 1 }, new SectionModel { SectionId = 2 } }
            };
            var destination = mapper.Map<SourceExamModel, DestinationExamModel>(source);
        }
    }
    public class SourceExamModel
    {
        public int ExamId { get; set; }
        public List<SectionModel> Sections { get; set; }
    }
    public class DestinationExamModel
    {
        public int ExamId { get; set; }
        public List<SectionModel> DestSections { get; set; }
    }
    public class SectionModel
    {
        public int SectionId { get; set; }
    }
