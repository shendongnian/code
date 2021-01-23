    public class Customer : INotifyPropertyChanged
    {
         // INotifyPropertyChanged members
         public event PropertyChangedEventHandler PropertyChanged;
         public void OnPropertyChanged(PropertyChangedEventArgs e)
         {
            if (PropertyChanged != null)
                   PropertyChanged(this, e);
         }
         // Your property
         private string _Name;
         public string Name
         {
           get
           {
                return _Name;
           }
           set
           {
               _Name = value;
               OnPropertyChanged(new PropertyChangedEventArgs("Name"));
           }
         }
    }   
