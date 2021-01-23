    public class OrcamentoInsumo
    {
        public Guid OrcamentoId { get; set; }
        [ForeignKey("CR")]
        public Guid CRId { get; set; }
        public virtual CR CR { get; set; }
        public String CodigoTron { get; set; }
        [ForeignKey("Insumo")]
        public Guid InsumoId { get; set; }
        public virtual Insumo Insumo { get; set; }
        [ForeignKey("Familia")]
        public Guid FamiliaId { get; set; }
        public virtual Familia Familia { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; } 
        public virtual bool IsIAC { get; protected set; }
        public virtual bool IsINOC { get; protected set; }
    }
