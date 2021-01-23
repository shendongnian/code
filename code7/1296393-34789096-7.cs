    class Program
        {
            static void Main(string[] args)
            {
    
                using (var repo = new RepositoryDal())
                {
                    var shelfbll = new ShelfBll(repo);
                    var bookBll = new BookBll(repo);
                    var shelf = new Shelf { Location = "some location" };
                    var book = new Book() { Name = "some book" };
                    shelfbll.AddShelf(shelf);
                    book.ShelfId = shelf.Id;
                    bookBll.AddBook(book);
                }
            }
        }
