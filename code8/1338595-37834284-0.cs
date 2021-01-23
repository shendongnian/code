    [Table("Member")]
    public partial class Member
    {
        public Member() {}
        public virtual int ID { get; set; }
        public int? SeedID { get; set; }
        public virtual Seed Seed1 { get; set; }
        ...
    }
    [Table("Seed")]
    public partial class Seed : Member
    {
        public Seed()
        {
            Members = new HashSet<Member>();
        }
        public override int ID
        {
            get { return MemberID; }
            set { MemberID = value; }
        }
        [NotMapped]
        public int MemberID { get; set; }
        public int Locale { get; set; }
    }
    public class SeedMap : EntityTypeConfiguration<Seed>
    {
        public SeedMap()
        {
            HasKey(c => c.ID);
            Property(c => c.ID)
                .HasColumnName("MemberID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(e => e.Members)
                .WithOptional(e => e.Seed1)
                .HasForeignKey(e => e.SeedID);
        }
    }
