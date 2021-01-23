    public class tblMyEntityMapper : EntityTypeConfiguration<tblMyEntityMap>
    {
           public tblMyEntityMapper()
           {
    		   this.Ignore(t => t. tblPropertyValues);
    	   }
    }
