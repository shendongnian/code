    namespace WebAppImaginario.Models
    {
    public class ItemCarrinho
      {
        public int idLivro { get; set; }
        [DisplayName("Quantidade do Produto")]
        public int qtdProduto { get; set; }
        [DisplayName("Nome do Produto")]
        public string nomeProduto { get; set; }
        [DisplayName("Descrição do Produto")]
        public string descProduto { get; set; }
        [DisplayName("Preço do Produto")]
        public decimal precProduto { get; set; }
        [DisplayName("Desconto da Promoção")]
        public decimal descontoPromocao { get; set; }
        [DisplayName("Imagem")]
        public byte[] imagem { get; set; }
      }
    }
