    public class FormaPagamento
    {
    
            public FormaPagamento()
            {
                this.ContasPagarReceber = new HashSet<ContaPagarReceber>();
                this.Movimentacoes = new HashSet<ContaPagarReceberMovimentacao>();
                this.ComprasVendas = new HashSet<CompraVenda>();
                this.CondicoesPagamento = new HashSet<CondicaoPagamentoFormaPagamento>();
            }
    
            public long ID_FormaPagamento { get; set; }
            public string Descricao { get; set; }
            public bool IsAtivo { get; set; }
            public bool IsSystem { get; set; }
            public int? Enum { get; set; }
    
            public virtual ICollection<ContaPagarReceber> ContasPagarReceber { get; set; }
            public virtual ICollection<ContaPagarReceberMovimentacao> Movimentacoes { get; set; }
    
            // When I removed this collection, it works.
            public virtual ICollection<CompraVenda> ComprasVendas { get; set; }
    
            public virtual ICollection<CondicaoPagamentoFormaPagamento> CondicoesPagamento { get; set; }
    
    }
