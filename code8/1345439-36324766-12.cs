    public class ViewModelexample : INotifyPropertyChanged
    {    
        private string _count;
        public string count { 
            get { return _count; } 
            set {
                if(value != _count) {
                    _count = value;
                    OnPropertyChanged(nameof(count));
                }
            } 
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged(string propertyName)
        {
            // the new Null-conditional Operators are thread-safe:
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private int _testCount = 0;
        public void Method() {
            testCount++;
            Debug.WriteLine(testCount.ToString());
            count = testCount.ToString();
        }
    
    }
