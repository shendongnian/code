	public class LibraryVM{
		
		public LibraryVM(LibraryModel model) {
			_model = model
		}
		private readonly LibraryModel _model;
		public List<BookVM> Books {get {return _model.Books.Select(b => new BookVM(v)).ToList();}}
	}
