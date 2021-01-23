    public class DetailsService : IDetailsService
        {
            private readonly IContentService _contentService; //BAD
    
    
            public GeneralService(IContentService contentService)
            {
                _contentService = contentService; //BAD
            }
