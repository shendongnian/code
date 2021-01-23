    namespace ClientConfiguration.Mappings {
        public class CustomDisplayNameAttribute : DisplayNameAttribute {
    
            private static IMappingBaseService _mappingBaseService { get; set; }
    
            public CustomDisplayNameAttribute(string value, IMappingBaseService mappingBaseService)
                : base(GetMessageFromResource(value, mappingBaseService)) {
            }
    
            private static string GetMessageFromResource(string value, IMappingBaseService mappingBaseService) {
                _mappingBaseService  = mappingBaseService;
                var els = _mappingBaseService .GetElements().ToList();
                //OR var els = mappingBaseService.GetElements().ToList();
                //get value from DB
                //mappingBaseService is always null
                return "";
            }
        }
    }
