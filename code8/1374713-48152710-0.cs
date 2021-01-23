    namespace myApp.Data.Models
    {   
        
        public partial class myDBEntities : DbContext
        {
            public myDBEntities()
               : base("name=myDBEntities")
            {
            }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                throw new UnintentionalCodeFirstException();
            }
    		
    }
