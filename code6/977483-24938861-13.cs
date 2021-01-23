    public class CardContainerConfiguration : EntityTypeConfiguration<CardContainer>
    {
        public CardContainerConfiguration()
        {
            ToTable("CardContainers");
            HasKey(k => k.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);   
            HasMany(f => f.Cards)
                .WithRequired(p => p.Container)
                .HasForeignKey(p => p.ContainerId)
                .WillCascadeOnDelete(true);
        }
    }
    
    public class ChassisConfiguration : EntityTypeConfiguration<Chassis>
    {
        public ChassisConfiguration()
        {
            ToTable("Chassis");
        }
    }
    
    public class CardConfiguration : EntityTypeConfiguration<Card>
    {
        public CardConfiguration()
        {
            ToTable("Cards");
            HasRequired(x => x.Container).WithMany(x => x.Cards).HasForeignKey(x => x.ContainerId);            
        }
    }    
