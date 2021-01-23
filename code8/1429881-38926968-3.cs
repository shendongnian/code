    public class VIewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] String propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
    public class NewsPageViewModel : ViewModelBase
    {
        public NewsPageViewModel()
        {
            Posts = GetPosts();
        }
        private ObservableCollection<Post> _posts;
        public ObservableCollection<Post> Posts
        {
            get { return _posts; }
            set {
                _posts = value;
                OnPropertyChanged();
            }
        }
        protected ObservableCollection<Post> GetPosts()
        {
            //  do stuff to get posts, return new ObservableCollection<Post>
        }
    }
