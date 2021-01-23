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
		#region Entities without 'join table'
		public class Novel
		{
			public int NovelId { get; set; }
			public string Title { get; set; }
			public ICollection<Novelist> Novelists { get; set; }
		}
		public class Novelist
		{
			public int NovelistId { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public ICollection<Novel> Novels { get; set; }
		}
		#endregion Entities without 'join table'
		#region Mock DbContext
		public class DbContext : IDisposable
		{
			// Mock DbSet<T> classes
			public List<Author> AuthorsDbSet { get; set; }
			public List<Book> BooksDbSet { get; set; }
			public List<Author_Book> Author_BooksDbSet { get; set; }
			public List<Novel> NovelsDbSet { get; set; }
			public List<Novelist> NovelistsDbSet { get; set; }
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
				seedBookAuthors();
				seedNovelsNovelists();
			}
			private void seedBookAuthors()
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
			private void seedNovelsNovelists()
			{
				var novels = new List<Novel>
				{
					new Novel {Title = "Crime and Punishment", NovelId = 1}, // Fyodor Dostoyevsky
					new Novel {Title = "Notes from Underground", NovelId = 5}, // Fyodor Dostoyevsky
					new Novel {Title = "War and Peace", NovelId = 2}, // Leo Tolstoy
					new Novel {Title = "The Idiot", NovelId = 4}, // Leo Tolstoy
					new Novel {Title = "The Master and Margarita", NovelId = 3} // Mikhail Bulgakov
				};
				var writers = new List<Novelist>
				{
					new Novelist {FirstName = "Fyodor", LastName = "Dostoyevsky", NovelistId = 1},
					new Novelist {FirstName = "Leo", LastName = "Tolstoy", NovelistId = 2},
					new Novelist {FirstName = "Mikhail", LastName = "Bulgakov", NovelistId = 3},
				};
				using (var ctx = new DbContext())
				{
					ctx.NovelsDbSet.AddRange(novels);
					ctx.NovelistsDbSet.AddRange(writers);
					ctx.SaveChanges();
				}
				using (var ctx = new DbContext())
				{
					var dostoyevsky = ctx.NovelistsDbSet.FirstOrDefault(d => d.NovelistId == 1);
					var crime = ctx.NovelsDbSet.FirstOrDefault(n => n.NovelId == 1);
					var underground = ctx.NovelsDbSet.FirstOrDefault(n => n.NovelId == 5);
					dostoyevsky.Novels.Add(crime);
					underground.Novelists.Add(dostoyevsky);
					var tolstoy = ctx.NovelistsDbSet.FirstOrDefault(d => d.NovelistId == 2);
					var war = ctx.NovelsDbSet.FirstOrDefault(n => n.NovelId == 2);
					var idiot = ctx.NovelsDbSet.FirstOrDefault(n => n.NovelId == 4);
					tolstoy.Novels.Add(war);
					idiot.Novelists.Add(tolstoy);
					var bulgakov = ctx.NovelistsDbSet.FirstOrDefault(d => d.NovelistId == 3);
					var master = ctx.NovelsDbSet.FirstOrDefault(n => n.NovelId == 3);
					master.Novelists.Add(bulgakov);
					ctx.SaveChanges();
				}
			}
			/// <summary>
			/// Example using the join table 'Authors_Tables'
			/// as part of the Entities to do operations on the n:m-relationship
			/// between Author <-> Book
			/// </summary>
			public void SwitchAuthorsWithJoinTable()
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
			/// <summary>
			/// Example for operations on the n:m-relationship between
			/// Novelist <-> Novel without the join table 'Novelists_Novels'
			/// being part of the Entities.
			///
			/// I.  All Books from Dostoyevsky to Tolstoy.
			/// II. Add Bulgakov as Author of 'War and Peave'
			/// </summary>
			public void SwitchAuthorsWithoutJoinTable()
			{
				// I.
				using (var ctx = new DbContext())
				{
					var dostoyevsky = ctx.NovelistsDbSet.FirstOrDefault(n => n.LastName == "Dostoyevsky");
					var tolstoy = ctx.NovelistsDbSet.FirstOrDefault(n => n.LastName == "Tolstoy");
					var booksOfDostoyevsky = dostoyevsky.Novels.ToList();
					// add all novels of Dostoyevsky to Tolstoy
					booksOfDostoyevsky.ForEach(b => tolstoy.Novels.Add(b));
					// clear all novels belonging to Dostoyevsky
					dostoyevsky.Novels.Clear();
					// save it all!
					ctx.SaveChanges();
				}
				// II.
				using (var ctx = new DbContext())
				{
					Func<string, string, bool> compare = (target, pattern) =>
						target.ToLower().Contains(pattern.ToLower());
					var war = ctx.NovelsDbSet.FirstOrDefault(n => compare(n.Title, "war"));
					var bulgakov = ctx.NovelistsDbSet.FirstOrDefault(n => n.LastName == "Bulgakov");
					war.Novelists.Add(bulgakov);
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
			/// <summary>
			/// Instead of replacing entire collections of Novelists
			/// in order to remove or add a single entity to the relationship
			/// its possible to just add or delete single records
			///
			/// I.  Remove Dostoyevsky as Novelist from 'War and Peace'
			/// II. Add Tolstoy and Bulgakov as additional Novelists to 'Crime and Punishment'
			/// </summary>
			public void DeletingAndAddingSingleNovelists()
			{
				// I.
				using (var ctx = new DbContext())
				{
					// get the novel 'War and Peace' from the database
					var war = ctx.NovelsDbSet.FirstOrDefault(n => n.Title == "War and Peace");
					Novelist dostoyevsky = null;
					// havent done that so far but you should
					// always check if the query actually returned something
					if (war != null)
					{
						// EF's LazyLoading mechanism allows you to query/traverse navigation properties
						// on your entities which is the ICollection<Novelist> Novelists on Novels
						// it automatically loads the associated entities which are the novelists
						dostoyevsky = war.Novelists.FirstOrDefault(n => n.LastName == "Dostoyevsky");
					}
					if (dostoyevsky != null)
					{
						// remove Dostoyevsky from 'War and Peace'
						war.Novelists.Remove(dostoyevsky);
					}
					// save it all!
					ctx.SaveChanges();
				}
				// II.
				using (var ctx = new DbContext())
				{
					var novelists = ctx.NovelistsDbSet.Where(n =>
						n.LastName == "Tolstoy"
						|| n.LastName == "Bulgakov");
					if (novelists != null && novelists.Any())
					{
						var crime = ctx.NovelsDbSet.FirstOrDefault(n => n.Title == "Crime and Punishment");
						if (crime != null)
						{
							Debug.WriteLine(String.Format("'{2]' currenty has {0} {1}.",
								crime.Novelists.Count, crime.Novelists.Count == 1 ? "Author" : "Authors", crime.Title));
							// assign the targeted novelists to 'Crime and Punishment'
							novelists.ToList().ForEach(n => crime.Novelists.Add(n));
							// save it all!
							ctx.SaveChanges();
						}
					}
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
				dbOps.SwitchAuthorsWithoutJoinTable();
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
				dbOps.SwitchAuthorsWithJoinTable();
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
