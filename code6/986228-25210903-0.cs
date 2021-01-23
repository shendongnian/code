    public partial class Entities : DbContext
    {
        public Entities()
            : base(BuildConnectionString)
        {
        }
        ...
    }
