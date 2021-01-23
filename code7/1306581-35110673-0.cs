	public class Book
	{
		public int Author { get; set; }
		public string Title { get; set; }
	}
	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	public static void NoIntellisenseInEnumerableJoin()
	{
		IEnumerable<Book> books = null;
		IEnumerable<Author> authors = null;
	var books_  = from book in books
                           select book;
						   
	var books = books.Include(book => book.Author);
						   
	books_ = books_.Where(authors, book => book.Author.Id, // to do.
	
						
						
						
						
