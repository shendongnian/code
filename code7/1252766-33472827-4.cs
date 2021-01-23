    public class MainWindowViewModel:INotifyPropertyChanged
        {        
            private ObservableCollection<Person> _persons=new ObservableCollection<Person>();
            public ObservableCollection<Person> Persons
            {
                get
                {
                    return _persons=GetData();
                }
                set
                {
                    _persons = value;
                    OnPropertyChanged("Persons");
                }
            }        
    
            public ObservableCollection<Person> GetData()
            {
                 myDataList.Add(new Person() { ID = 1, Name = "Person1", Author = "Author1", Price = "6.7 TL", Catalog = "IT", IsClickable=true});
                 myDataList.Add(new Person() { ID = 2, Name = "Person2", Author = "Author2", Price = "9.7 TL", Catalog = "IT", IsClickable = false});
                 myDataList.Add(new Person() { ID = 3, Name = "Person3", Author = "Author3", Price = "11.7 TL", Catalog = "IT", IsClickable = true});
                 myDataList.Add(new Person() { ID = 2, Name = "Person4", Author = "Author2", Price = "9.7 TL", Catalog = "IT", IsClickable = true});
                 myDataList.Add(new Person() { ID = 3, Name = "Person5", Author = "Author3", Price = "11.7 TL", Catalog = "IT", IsClickable = false});
                if (myDataList.Count > 0)
                {
                    return myDataList;
                }
                else
                    return null;
            }
            RelayCommand _clickCommand = null;
            public ICommand SomeClickCommand
            {
               get
               {
                  if (_clickCommand == null)
                    {
                       _clickCommand = new RelayCommand((p) => OnClick(p), (p) => CanClick(p));
                    }
                return _clickCommand;
               }
            }
            private bool CanClick(object obj)
            {
               return true;
            }
            private void OnClick(object obj)
            {
               MessageBox.Show("You clicked:)");
            }
    
            #region OnPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("propertyName"));
            }
            #endregion
        } 
