    public partial class Apolices
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("ProdutosRamos")]
        public int CodProduto { get; set; }
    
        [Key]
        [Column(Order = 1)]
        [ForeignKey("ProdutosRamos")]
        public int CodRamo
        {
            get; set;
        }
    
        [StringLength(50)]
        public string Descricao { get; set; }
    
        public virtual ProdutosRamos ProdutosRamos { get; set; }
    }
    
    
    public partial class Produtos
    {  
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodProduto { get; set; }
    
        [StringLength(50)]
        public string Descricao { get; set; }
    }
    
    
    public partial class Ramos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodRamo { get; set; }
    
        [StringLength(50)]
        public string Descricao { get; set; }
    }
    
    public partial class ProdutosRamos
    {  
        [Key]
        public int CodProduto { get; set; }
    
        [Key]
        public int CodRamo { get; set; }
        
        [ForeignKey("CodProduto")]
        public virtual Produtos Produtos { get; set; }
    
        [ForeignKey("CodRamo")]
        public virtual Ramos Ramos { get; set; }
    }
