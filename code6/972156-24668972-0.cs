    public class Organisation {
    public int Id { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
    }
    public class Course {
        public int Id { get; set; }
        public virtual Organisation Organisation { get; set; }
    }
   
     public class OrganisationSchema : EntityTypeConfiguration<Organisation>
    {
        public OrganisationSchema()
        {
            ToTable(typeof(Organisation).Name);            
            HasMany(x => x.Courses).WithRequired(x => .Organisation).WillCascadeOnDelete();
        }
    }
