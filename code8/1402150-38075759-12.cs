	public class LibraryVM{
		
		public LibraryVM(LibraryModel model) {
			_model = model
		}
		#region CmdRemove
		private DelegateCommand _cmdRemove;
        public DelegateCommand CmdRemove {
            get { return _cmdRemove ?? (_cmdRemove = new DelegateCommand(Remove, CanRemove)); }
        }
        private void Remove(Object parameter) {
        	BookVM bookToRemove = (BookVM)parameter;
        	Books.Remove(bookToRemove);
        }
        private void CanRemove(Object parameter) {
        	BookVM bookToRemove = parameter as BookVM;
        	return bookToRemove != null && Books.Contains(bookToRemove);
        }
		#endregion
		private readonly LibraryModel _model;
		public List<BookVM> Books {get {return _model.Books.Select(b => new BookVM(b)).ToList();}}
	}
