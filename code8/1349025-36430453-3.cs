    public enum Category
    {
        ProgrammingBooks,
        CookingBooks
    }
    public interface IBook
    {
        Category BookType { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        // ...
    }
    public class ProgrammingBook: IBook
    {
        public ProgrammingBook()
        {
            this.BookType = Category.ProgrammingBooks;
        }
        public string Author { get; set; }
        public string Title { get; set; }
        public Category BookType { get; set; }
        // ...
    }
    public class CookBook : IBook
    {
        public CookBook()
        {
            this.BookType = Category.CookingBooks;
        }
        public string Author { get; set; }
        public string Title { get; set; }
        public Category BookType { get; set; }
        // ...
    }
