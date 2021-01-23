    public class MyViewConfiguration : EntityTypeConfiguration<MyView>      
    {
        public MyViewConfiguration()
        {
            this.HasKey(t => t.Id);
            this.ToTable("myView");
        }   
    }
