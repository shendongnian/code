    namespace IDFWebApp.Models.Custom
    {
        public class RegistrantsModel
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public organizationrolety RoleType { get; set; }
        }
        public class RegistrantsIndexModel
        {
            public string RaceEvent { get; set; }
            public IEnumerable<IDFWebApp.Models.Custom.RegistrantsModel> Registrants { get; set; }
        }
    }
