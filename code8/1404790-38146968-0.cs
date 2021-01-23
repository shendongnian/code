        public class Catalog
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime CatalogDate { get; set; }
        }
        public class Book
        {
            public int BookId { get; set; }
            public int CatalogId { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
       
         }
        
        public class CatalogViewModel
        {
            public int SelectedCatalog { get; set; }
            public List<Catalog> Catalogs { get; set; }
        }
        public class BookViewModel
        {
            public int SelectedBook { get; set; }
            public List<Book> Books { get; set; }
        }
