    public class Person
    {
        public int Id {get; set;}
        private int _idProfile;
        public int IdProfile {
            get{
                return _idProfile == 0 ? DEFAULT_PROFILE_ID : _idProfile;
            }
            set{
                _idProfile  = value;
            }
        }
        public virtual Profile @Profile;
    }
    
    public class Profile
    {
        public int Id {get; set;}
        public virtual ICollection<Person> Persons { get; set; }
    }
    /* MAPPING */
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        this.HasRequired(t => t.Profile)
                .WithMany(t => t.Persons)
                .HasForeignKey(d => d.IdProfile);
    }
