    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MemberMapping : EntityTypeConfiguration<Member>
    {
        public MemberMapping()
        {
            this.HasKey(m => m.Id);
            this.Property(m => m.Name).IsRequired();
        }
    }
