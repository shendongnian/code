     public class ViewModel : INotifyPropertyChanged
        {
            public ViewModel()
            {
                List<comboItem> list = new List<comboItem>();
                list.Add(new comboItem(new BitmapImage(new Uri("/WpfApplication1;component/Images/FT-C2HB.JPEG", UriKind.Relative)), "Stk"));
                list.Add(new comboItem(new BitmapImage(new Uri("//WpfApplication1//Images//FT-C2HB.JPEG", UriKind.Relative)), "abc"));
                _comboboxitems = new CollectionView(list);
            }
            private readonly CollectionView _comboboxitems;
            private comboItem _comboitem;
    
            public CollectionView Comboboxitems
            {
                get { return _comboboxitems; }
            }
    
            public comboItem Comboitem
            {
                get { return _comboitem; }
                set
                {
                    if (_comboitem == value) return;
                    _comboitem = value;
                    OnPropertyChanged("Comboitem");
                }
            }
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
