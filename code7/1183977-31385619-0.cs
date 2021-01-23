    public class Categoria
    {
        public int ID {get; set}
        private List<Produto> produto {get; set;}
        public int produtoCount {get {return produto.Count();} }
    }
    
    public class Produto
    {
        public ID {get; set}
        public string data {get; set;}
    }
