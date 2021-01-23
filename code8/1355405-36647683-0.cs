		public class Book
		{
			// a property "Id" or ClassName + "Id" is treated as primary key. 
			// No annotation needed.
			public int BookId { get; set; }
			// without [StringLenth(123)] it's created as NVARCHAR(MAX)
			[Required]
			public string Text { get; set; }
			// optionally if you need the pages in the book object:
			// Usually I saw ICollections for this usage.
			// Without lazy loading virtual is probably not necessary.
			public virtual ICollection<BookPage> BookPages { get; set; }
		}
		public class BookPage
		{
			public int BookPageId { get; set; }
			// With the following naming convention EF treats those two property as 
			// on single database column. This automatically corresponds
			// to ICollection<BookPage> BookPages of Books.
			// Required is not neccessary if "BookId" is int. If not required use int?
			// A foreign key relationship is created automatically. 
			// With RC2 also an index is created for all foreign key columns.
			[Required]
			public Book Book { get; set; }
			public int BookId { get; set; }
			[Required]
			public PageTitle PageTitle { get; set; }
			public int PageTitleId { get; set; }
			public int Number { get; set; }
		}
		public class PageTitle
		{
			public int PageTitleId { get; set; }
			// without StringLenth it's created as NVARCHAR(MAX)
			[Required]
			[StringLength(100)]
			public string Title { get; set; }
		}
