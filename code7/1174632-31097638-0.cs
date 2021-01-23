		using System;
		using System.Collections.Generic;
		using System.Diagnostics;
		using System.Linq;
		namespace EntityFrameworkManyToMany
		{
			#region Entities
			public class Book
			{
				public int BookId { get; set; }
				public string BookName { get; set; }
				public ICollection<Author_Book> Authors { get; set; }
			}
			public class Author
			{
				public int AuthorId { get; set; }
				public string AuthorName { get; set; }
				public ICollection<Author_Book> Books { get; set; }
			}
			public class Author_Book
			{
				// has 1 Author
				public int AuthorId { get; set; }
				// has 1 Book
				public int BookId { get; set; }
				public Author Author { get; set; }
				public Book Book { get; set; }
			}
			#endregion Entities
			#region Mock DbContext
			public class DbContext : IDisposable
			{
				// Mock DbSet<T> classes
				public List<Author> AuthorsDbSet { get; set; }
				public List<Book> BooksDbSet { get; set; }
				public List<Author_Book> Author_BooksDbSet { get; set; }
				// so we can use 'using'
				public void Dispose()
				{
				}
				// Mock SaveChanges Method from EF's DbContext-Class
				public void SaveChanges()
				{
				}
			}
			#endregion Mock DbContext
			#region DbOperations for initial seeding, then switching and reassiging
			public class DbOperations
			{
				// fill database with values
				public void SeedDb()
				{
					var authors = new List<Author>
					{
						new Author {AuthorId = 1, AuthorName = "Marc Twain"},
						new Author {AuthorId = 2, AuthorName = "Pushkin"}
					};
					var books = new List<Book>
					{
						new Book {BookId = 1, BookName = "American Literary Regionalism"},
						new Book {BookId = 2, BookName = "American Realism"},
						new Book {BookId = 3, BookName = "The Bronze Horseman"},
						new Book {BookId = 4, BookName = "Poltava"},
					};
					using (var ctx = new DbContext())
					{
						ctx.AuthorsDbSet.AddRange(authors);
						ctx.BooksDbSet.AddRange(books);
						ctx.SaveChanges();
					}
					using (var ctx = new DbContext())
					{
						var pushkin = ctx.AuthorsDbSet.FirstOrDefault(a =>
							a.AuthorName.ToLower() == "pushkin");
						var pushkinsBooks = ctx.BooksDbSet.Where(b => b.BookId > 2).ToList();
						var pushkinAuthor_Books = pushkinsBooks.Select(pb => new Author_Book
						{
							AuthorId = pushkin.AuthorId,
							BookId = pb.BookId
						}).ToList();
						ctx.Author_BooksDbSet.AddRange(pushkinAuthor_Books);
						var twain = ctx.AuthorsDbSet.FirstOrDefault(a =>
							a.AuthorName.ToLower() == "Marc Twain");
						var twainsBooks = ctx.BooksDbSet.Where(b => b.BookId < 3).ToList();
						var twainAuthor_Books = twainsBooks.Select(tb =>
							new Author_Book
							{
								AuthorId = twain.AuthorId,
								BookId = tb.BookId
							}).ToList();
						ctx.Author_BooksDbSet.AddRange(twainAuthor_Books);
						ctx.SaveChanges();
					}
				}
				public void SwitchAuthors()
				{
					using (var ctx = new DbContext())
					{
						var twainsBooks = ctx.Author_BooksDbSet.Where(ab =>
							ab.AuthorId == ctx.AuthorsDbSet.FirstOrDefault(a =>
								a.AuthorName.ToLower() == "marc twain").AuthorId).ToList();
						var pushkinsBooks = ctx.Author_BooksDbSet.Where(ab =>
							ab.AuthorId == ctx.AuthorsDbSet.FirstOrDefault(a =>
								a.AuthorName.ToLower() == "marc pushkin").AuthorId).ToList();
						// assign all of Twain's books to Pushkin
						twainsBooks.ForEach(tb => tb.AuthorId = pushkinsBooks.FirstOrDefault().AuthorId);
						// assign all of Pushkin's books to Twain
						pushkinsBooks.ForEach(pb => pb.AuthorId = twainsBooks.FirstOrDefault().AuthorId);
						// EF tracks the changes and a call to SaveChanges
						// propagates the modifications to the database
						ctx.SaveChanges();
					}
				}
				public void AssignEverythingToTwain()
				{
					Author twain;
					List<Book> nonTwainBooks;
					using (var ctx = new DbContext())
					{
						twain = ctx.AuthorsDbSet.FirstOrDefault(a => a.AuthorName.ToLower() == "marc twain");
						// find all books that are not from Twain in the "Books"-Table
						nonTwainBooks = ctx.BooksDbSet.Where(b => b.Authors.Any(a =>
							a.AuthorId != twain.AuthorId)).ToList();
						// find all Author_Book entities for authors that are not Twain
						// this search is done in the join table 'Authors_Books'
						var nonTwain_AuthorBooks = ctx.Author_BooksDbSet.Where(ab =>
							nonTwainBooks.Any(nonTwainBook => nonTwainBook.BookId == ab.BookId)).ToList();
						// finally remove all those entries in the join table 'Authors_Books'
						nonTwain_AuthorBooks.ForEach(nonTB => ctx.Author_BooksDbSet.Remove(nonTB));
						// propagate changes to database
						ctx.SaveChanges();
					}
					using (var ctx = new DbContext())
					{
						// create new 'Author_Book' entities for all books that previously where not Twains
						var reassigningBooksToTwain = nonTwainBooks.Select(b => new Author_Book
						{
							AuthorId = twain.AuthorId,
							BookId = b.BookId
						}).ToList();
						// add those entities to the database
						ctx.Author_BooksDbSet.AddRange(reassigningBooksToTwain);
						// propagate changes to database
						ctx.SaveChanges();
					}
				}
			}
			#endregion DbOperations for initial seeding, then switching and reassiging
			#region Execution and verifying results
			public static class Core
			{
				public static void Main(string[] args)
				{
					var dbOps = new DbOperations();
					dbOps.SeedDb();
					AssertAuthorSwitch(dbOps);
				}
				public static bool AssertAuthorSwitch(DbOperations dbOps)
				{
					string pushkin_Poltava = "Poltava";
					string twain_AmericanRealism = "American Realism";
					Author twain;
					Author pushkin;
					Book americanRealism;
					Book poltava;
					bool hasPassedBefore = false;
					bool hasPassedAfter = false;
					using (var ctx = new DbContext())
					{
						twain = ctx.AuthorsDbSet.FirstOrDefault(a => a.AuthorName == "Marc Twain");
						pushkin = ctx.AuthorsDbSet.FirstOrDefault(a => a.AuthorName == "Pushkin");
						americanRealism = twain.Books.FirstOrDefault(b =>
							b.Book.BookName == twain_AmericanRealism).Book;
						poltava = pushkin.Books.FirstOrDefault(b =>
							b.Book.BookName == pushkin_Poltava).Book;
					}
					//before
					using (var ctx = new DbContext())
					{
						var isPushkins = ctx.Author_BooksDbSet.Any(ab =>
							ab.AuthorId == pushkin.AuthorId
							&& ab.BookId == poltava.BookId);
						var isTwains = ctx.Author_BooksDbSet.Any(ab =>
							ab.AuthorId == twain.AuthorId
							&& ab.BookId == americanRealism.BookId);
						hasPassedBefore = isPushkins && isTwains;
						Debug.WriteLine("AssertAuthorSwitch {0} asserts to {1}", "before", hasPassedBefore);
					}
					dbOps.SwitchAuthors();
					//after
					using (var ctx = new DbContext())
					{
						var isPushkins = ctx.Author_BooksDbSet.Any(ab =>
							ab.AuthorId == pushkin.AuthorId
							&& ab.BookId == americanRealism.BookId);
						var isTwains = ctx.Author_BooksDbSet.Any(ab =>
							ab.AuthorId == twain.AuthorId
							&& ab.BookId == poltava.BookId);
						hasPassedAfter = isPushkins && isTwains;
						Debug.WriteLine(String.Format("AssertAuthorSwitch {0} asserts to {1}", "after", hasPassedAfter));
					}
					Debug.WriteLine(String.Format("AssertAuthorSwitch asserts to {0}", hasPassedBefore && hasPassedAfter));
					return hasPassedBefore && hasPassedAfter;
				}
				public static bool AssertAssigningToTwain(DbOperations dbOps)
				{
					// you get the idea
					return true;
				}
			}
			#endregion Execution and verifying results
		}
