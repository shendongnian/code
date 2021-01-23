    [Table("tempTable")]
    public partial class tempTable
    {
        public tempTable()
        {
            tempTable1 = new HashSet<tempTable>();
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        
        [StringLength(1)]
        public string name { get; set; }
        
        public int? managerid { get; set; }
        
        public virtual ICollection<tempTable> tempTable1 { get; set; }
        
        public virtual tempTable tempTable2 { get; set; }
    }
        
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tempTable>()
                    .Property(e => e.name)
                    .IsUnicode(false);
        
        modelBuilder.Entity<tempTable>()
                    .HasMany(e => e.tempTable1)
                    .WithOptional(e => e.tempTable2)
                    .HasForeignKey(e => e.managerid);
    }
