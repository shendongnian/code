    public enum ProgrammingLanguage
    {
        CSharp,
        Java,
        Cpp
    }
    public class ProgrammingBook: IBook
    {
        // a constructor that takes the ProgrammingLanguage as argument
        public ProgrammingBook(ProgrammingLanguage language)
        {
            this.BookType = Category.ProgrammingBooks;
            this.Language = language;
        }
        public ProgrammingLanguage Language { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public Category BookType { get; set; }
        // ...
    }
