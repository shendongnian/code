    public partial class PublicAreaContext : DbContext, IDataContext
    {
        public PublicAreaContext() 
            : base("PublicAreaContext") //Here go the name of connection string
        {
        }
    
        ...
    }
