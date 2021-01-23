    public class BookRepository : IBookRepository
    {
        private UnitOfWork _unitOfWork;
     
        public IQueryable<Book> Books
        {
            get { return _unitOfWork.DBBooks; }
        }
     
        public BookRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
     
        public void Add(Book model)
        {
            _unitOfWork.DBBooks.Add(model);
        }
     
        public void Remove(Book model)
        {
            _unitOfWork.DBBooks.Remove(model);
        }
    }
