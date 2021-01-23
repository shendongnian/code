    class YourModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        ..
        ..
        public YourModel() {
            this.MyCollection = ...;
            this.MyCollection.CollectionChanged += MyCollection_CollectionChanged;
        }
        public bool IsDeleteOptionEnable {             
           get {
               return MyCollection.Count() >= 2;
            }
        }
        private void MyCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
             this.OnPropertyChanged("IsDeleteOptionEnable");
        }
        private void OnPropertyChanged(string name = null) {
             if (this.PropertyChanged != null) {
                PropertyChangedEventArgs ea = new PropertyChangedEventArgs(name);
                this.PropertyChanged(this, ea);
             }
         }
    }
