    public class ResponseHeader
    {
        public ResHeader ResHeader { get; set; }
    }
    public class ResHeader
    {
        public ServiceResStatus ServiceResStatus { get; set; }
        public Error[] Errors { get; set; }
    }
    public class Error
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
    }
    public class ServiceResStatus
    {
        public string ServiceResCode { get; set; }
        public string ServiceResDesc { get; set; }
        public System.DateTime ServiceRespDateTime { get; set; }
        public string ServiceUniqueRefNo { get; set; }
    }
    public class ExceptionInformation
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ExceptionInformation, Error>();
                cfg.CreateMap<ExceptionInformation, ResHeader>()
                    .ForMember(d => d.Errors, opts => opts.MapFrom(src => new[] {src}))
                    .ForMember(d => d.ServiceResStatus, opts => opts.Ignore());
                cfg.CreateMap<ExceptionInformation, ServiceResStatus>()
                    .ForMember(d => d.ServiceResCode, opts => opts.MapFrom(src => src.Code))
                    .ForMember(d => d.ServiceResDesc, opts => opts.MapFrom(src => src.Description))
                    .ForMember(d => d.ServiceRespDateTime, opts => opts.MapFrom(src => DateTime.Now))
                    .ForMember(d => d.ServiceUniqueRefNo, opts => opts.Ignore());
                cfg.CreateMap<ExceptionInformation, ServiceResStatus>()
                    .ForMember(d => d.ServiceResCode, opts => opts.MapFrom(src => src.Code))
                    .ForMember(d => d.ServiceResDesc, opts => opts.MapFrom(src => src.Description))
                    .ForMember(d => d.ServiceRespDateTime, opts => opts.MapFrom(src => DateTime.Now))
                    .ForMember(d => d.ServiceUniqueRefNo, opts => opts.Ignore());
                cfg.CreateMap<ExceptionInformation, ResponseHeader>()
                    .ForMember(des => des.ResHeader, opt => opt.MapFrom(src => new ResHeader()
                    {
                        Errors = new Error[1] { new Error() {Code = src.Code, Description = src.Description, Source = src.Source }},
                        ServiceResStatus = new ServiceResStatus() { ServiceResCode = src.Code, ServiceResDesc = src.Description, ServiceRespDateTime = DateTime.Now, ServiceUniqueRefNo = null}
                    }));
            });
            var mapper = config.CreateMapper();
            var info = new ExceptionInformation()
            {
                Code = "ERR01",
                Description = "Error",
                Source = "Oven"
            };
            var dto1 = mapper.Map<ExceptionInformation, Error>(info);
            var dto2 = mapper.Map<ExceptionInformation, ResHeader>(info);
            var dto3 = mapper.Map<ExceptionInformation, ServiceResStatus>(info); 
            var dto4 = mapper.Map<ExceptionInformation, ResponseHeader>(info);
            
            //Put a check point in cole readline and verify objects dto1, dto2, dto3 and dto4
            Console.ReadLine();
        }
    }
}`
