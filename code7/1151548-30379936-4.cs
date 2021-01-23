    namespace MyCompany.MyProject.DomainModels
    {
        // this separation may seem like overkill, but when you come to
        // want different business models than your domain models, or to decorate
        // this model with Entity Framework specific attributes, you'll be glad
        // for the separation.
        public class Report
        {
            public int Id { get; set; }
            public virtual Employee Manager { get; set; }
            public virtual Employee Employee { get; set; }
        }
    }
