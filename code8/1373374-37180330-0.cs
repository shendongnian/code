     public class ClientElementsViewModel {
            private static IMappingBaseService _mappingBaseService;
            public ClientElementsViewModel(IMappingBaseService mappingBaseService) {
                _mappingBaseService = mappingBaseService;
            }
            [Key]
            [Display(Name = "Id")]
            public long ClientElementId { get; set; }
            [CustomDisplayName("", _mappingBaseService)]
            public string CompanyCode { get; set; }
            //[CustomDisplayName("")]
            public string WebAppBaseUrl { get; set; }
            //[CustomDisplayName("")]
            public string GuestTraveller { get; set; }
        }
