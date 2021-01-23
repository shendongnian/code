    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    
        bool _a;
        public bool A
        {
            get { return _a || _b; }
            set {
                  if (_a == value) return;
                  _a = value; 
                  OnPropertyChanged("A");
                  OnPropertyChanged("B");
                }
        }
    
        bool _b;
        public bool B
        {
            get { return _b || _a; }
            set {
                  if (_b == value) return;
                  _b = value; 
                  OnPropertyChanged("B");
                  OnPropertyChanged("A");
                }
        }
    }
