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
                ObservableCollection<Person> myDataList = new ObservableCollection<Person>();
                myDataList.Add(new Person() { ID = 1, Name = "Person1", Author = "Author1", Price = "6.7 TL", Catalog = "IT" });
                myDataList.Add(new Person() { ID = 2, Name = "Person2", Author = "Author2", Price = "9.7 TL", Catalog = "IT" });
                myDataList.Add(new Person() { ID = 3, Name = "Person3", Author = "Author3", Price = "11.7 TL", Catalog = "IT" });
                if (myDataList.Count > 0)
                {
                    return myDataList;
                }
                else
                    return null;
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
