        string authorName=item.Author.Name;
    }
    To achieve this you need to add one more property (navigation property to Author) in your book class:
    public class Book {
       public long Id { get; set; }
       public string Name { get; set; }
       public long AuthorId { get; set;}
       public virtual Author Author { get; set; }
    }
