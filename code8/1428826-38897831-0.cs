    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Merchant, MerchantAccountRequest>()
                    .ForMember(dest => dest.Individual, c => c.MapFrom(source => source.MerchantIndividual));
                cfg.CreateMap<MerchantIndividual, IndividualRequest>();
            });
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            var merchant = new Merchant
            {
                Id = 1,
                MerchantIndividual = new MerchantIndividual { FirstName = "John Doe" }
            };
            var merchantAccountRequest = mapper.Map<Merchant, MerchantAccountRequest>(merchant);            
        }
    }
    public class Merchant
    {
        public int Id { get; set; }
        public MerchantIndividual MerchantIndividual { get; set; }
    }
    public class MerchantIndividual
    {
        public string FirstName { get; set; }
    }
    public class MerchantAccountRequest
    {
        public int Id { get; set; }
        public IndividualRequest Individual { get; set; }
    }
    public class IndividualRequest
    {
        public string FirstName { get; set; }
    }
