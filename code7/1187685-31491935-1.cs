    class BaseViewModel : INotifyPropertyChanged
    {
           public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    class MainViewModel 
    {
        public BaseViewModel ArticleViewModel { get; set; }
    }
    class SubArticleViewModel : BaseViewModel
    {
        
    }
