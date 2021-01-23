    public class BookBll
        {
            private readonly IRepositoryDal _repositoryDal;
            public BookBll(IRepositoryDal dal)
            {
                this._repositoryDal = dal;
            }
    
            public Book AddBook(Book book)
            {
                book = this._repositoryDal.Add(book);
                this._repositoryDal.Save();
    
                return book;
            }
        
        }
    public class ShelfBll
        {
            private readonly IRepositoryDal _repositoryDal;
            public ShelfBll(IRepositoryDal dal)
            {
                this._repositoryDal = dal;
            }
    
            public Shelf AddShelf(Shelf shelf)
            {
                shelf = this._repositoryDal.Add(shelf);
                this._repositoryDal.Save();
    
                return shelf;
            }
        
        }
