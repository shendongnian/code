        public class BooksViewModel : INotifyPropertyChanged {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Article> _books;
        public  ObservableCollection<Article> Books {
            get { return _books ?? (_books = new ObservableCollection<Article>()); }
            set {
                if(_books != value) {
                    _books = value;
                    OnPropertyChanged();
                }
            }
        }
        public async void LoadItems()
        {       
            //simulator delayed load       
                var bookCollection = await manager.GetAll();
                foreach (Article book in bookCollection.articles)
                {                 
                        books.Add(book);
                }
        }
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null) {
            System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null) { handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName)); }
        }
        }
