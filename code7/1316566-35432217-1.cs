    public partial class SchoolDBEntities : DbContext
    {
        public SchoolDBEntities(): base("name=SchoolDBEntities")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
    }
