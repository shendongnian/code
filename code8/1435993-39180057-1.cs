    public class LibraryInitiliser:DropCreateDatabaseAlways<LibraryDb>
    {
        protected override void Seed(LibraryDb context)
        {
            var book= new List<Author>
            {
                new Author() { AuthorName = "Naame1", Address = "dublin", Book= new List<Book>
                {
                    new Book() { BookName = "Naae1", PublishDate= DateTime.Parse("01/02/1981")  },
                     new Book() { BookName = "Naae1", PublishDate= DateTime.Parse("01/02/1981")  },
                    new Book() { BookName = "Naae1", PublishDate= DateTime.Parse("01/02/1981")  }
                } },
                new Author() { AuthorName = "Naame1", Address = "dublin", Book= new List<Book>
                {
                    new Book() { BookName = "Naae1", PublishDate= DateTime.Parse("01/02/1981")  },
                     new Book() { BookName = "Naae1", PublishDate= DateTime.Parse("01/02/1981")  },
                    new Book() { BookName = "Naae1", PublishDate= DateTime.Parse("01/02/1981")  }
                } },
                } }
                  
            };
            book.ForEach(m => context.Library.Add(m));
            context.SaveChanges();
            base.Seed(context);
        }
    }
