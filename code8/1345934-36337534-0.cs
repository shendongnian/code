    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Aplicacao> Aplicacoes { get; set; }
        public virtual ICollection<Opcional> Opcionais { get; set; }
    }
