        public partial class Unidade
        {
            public int IdUnidade { get; set; }
            public int? IdUnidadePai { get; set; }
            public string Nome { get; set; }
            public virtual Unidade IdUnidadePaiNavigation { get; set; }
            public virtual ICollection<Unidade> InverseIdUnidadePaiNavigation { get; set; }
         }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.HasKey(e => e.IdUnidade);
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar");
                entity.HasOne(d => d.IdUnidadePaiNavigation).WithMany(p => p.InverseIdUnidadePaiNavigation).HasForeignKey(d => d.IdUnidadePai);
            });
        }
