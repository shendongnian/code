    public class ProjectModel : INotifyPropertyChanged{
          private bool _isNcwrEnabled;
          public bool IsNcwrEnabled{
              get{ return _isNcwrEnabled; }
              set{ _isNcwrEnabled = value; OnPropertyChanged("IsNcwrEnabled"); }
          }
          private bool _isCommentEnabled;
          public bool IsCommentEnabled{
              get{ return _isCommentEnabled; }
              set{ _isCommentEnabled= value; OnPropertyChanged("IsCommentEnabled"); }
          }
          private bool _isImageEnabled;
          public bool IsImageEnabled{
              get{ return _isImageEnabled; }
              set{ _isImageEnabled= value; OnPropertyChanged("IsImageEnabled"); }
          }
        public void OnPropertyChanged(String prop)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
