    public class Anuncios {
        public int AnuncioId {get;set;}
        public string Titulo {get;set;}
        public ICollection<SubCategorias> SubCategorias {get;set;}
        public int SubCategoriaId{get;set;}
    }
