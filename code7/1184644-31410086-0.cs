    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pedido>()
                .HasKey(p => new { p.CLIENTE, p.CODIGO })
                .HasMany<DetalhePedido>(p => p.DetalhesPedido)
                .WithRequired(dp => dp.Pedido)
                .HasForeignKey(dp => new { dp.CLIENTE, dp.NRPEDIDO });
            modelBuilder.Entity<MaterialPedido>()
                .HasKey(mp => new { mp.NRPEDIDO, mp.CLIENTE, mp.CODIGO })
                .HasMany<DetalhePedido>(mp => mp.DetalhesPedido)
                .WithRequired(dp => dp.MaterialPedido)
                .HasForeignKey(dp => new { dp.NRPEDIDO, dp.CLIENTE, dp.MATERIAL });
        }
    [Table("MATERIAL_PEDIDO")]
    public class MaterialPedido : IValidatableObject
    {
        [Key, Required, Column(Order = 1)]
        public int NRPEDIDO { get; set; }
        [Key, Required, Column(Order = 2), ForeignKey("DadosCliente")]
        public int CLIENTE { get; set; }
        public virtual Cliente DadosCliente { get; set; }
        [Key, Column(Order = 3)]
        public string CODIGO { get; set; }
        public virtual ICollection<DetalhePedido> DetalhesPedido { get; set; }
    }
    [Table("DETALHE_PEDIDO")]
    public class DetalhePedido
    {
        [Key, Column(Order = 1)]
        public int NRPEDIDO { get; set; }
        [Key, Column(Order = 2)]
        public int CLIENTE { get; set; }
        [Key, Column(Order = 3)]
        public string MATERIAL { get; set; }
        [Key, Column(Order = 4)]
        public string CODIGO { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual MaterialPedido MaterialPedido { get; set; }
    }
    [Table("PEDIDO")]
    public class Pedido : IValidatableObject
    {
        [Key, Column(Order = 1), DisplayName("Cód Pedido"), Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CODIGO { get; set; }
        [Key, Column(Order = 2), Required, CustomValidation(typeof(GranitoEntities), "NotZero")]
        public int CLIENTE { get; set; }
        [ForeignKey("CLIENTE")]
        public virtual Cliente DadosCliente { get; set; }
        public virtual ICollection<DetalhePedido> DetalhesPedido { get; set; }
    }
