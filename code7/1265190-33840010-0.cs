    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Documents.Client;
    using Microsoft.Azure.Documents.Linq;
    
    var book = client.CreateDocumentQuery<Book>(collectionLink)
                        .Where(b => b.Title == "War and Peace")
                        .Where(b => b.Publishers.Any(p => p.IsNormalized()))
                        .AsEnumerable().FirstOrDefault();
    public class Book
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        public Author Author { get; set; }
        public int Price { get; set; }
        public List<string> Publishers { get; set; }
}
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
