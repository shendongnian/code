    static void Main(string[] args)
            {
    
                using (var factory = new ServiceFactory())
                {
                    var shelf = new Shelf { Location = "some location" };
                    var book = new Book() { Name = "some book" };
                    factory.ShelfService().AddShelf(shelf);
                    book.ShelfId = shelf.Id;
                    factory.BookService.AddBook(book);
                }
            }
