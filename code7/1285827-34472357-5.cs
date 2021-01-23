    public class YourViewModel:INotifyPropertyChanged 
    {
        private ObservableCollection<Person> persons;
        public ObservableCollection<Person> Persons
        {
           get { return persons; }
           set
           {
              persons = value;
              OnPropertyChanged("Persons");
            }
         }
       
         public  YourViewModel()
         {  
            FillThePersons();
        }
        private void FillThePersons()
        {
            persons = new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++)
            {
                persons.Add(new Person() { Name = "Bob " + i.ToString(),      
                ImageAddress="Images/peach.jpg" });// Images is the name folder in your project
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
 
        }
    } 
       
