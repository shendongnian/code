    public class PublicationSystemResolver : IMemberValueResolver<object, object, string, bool>
    {
        private readonly PublicationService _publicationService;
    
        public PublicationSystemResolver(PublicationService publicationService)
        {
            this._publicationService = publicationService;
        }
    
        public bool Resolve(object source, object destination, string sourceMember, bool destMember, ResolutionContext context)
        {
            return _publicationService.IsInNewSystem(sourceMember);
        }
    }
    
    
    
    cfg.CreateMap<FindCustomerServiceSellOffers, SalesPitchViewModel>()
        .ForMember(dest => dest.IsInNewSystem,
            src => src.ResolveUsing<PublicationSystemResolver, string>(s => s.PublicationCode));
