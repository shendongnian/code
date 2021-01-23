    public class CustomViewModel : INotifyPropertyChanged {
       public CustomViewModel(){
          //....
       }
       protected event PropertyChangedEventHandler propertyChanged;
       protected void OnPropertyChanged(string property){
          var handler = propertyChanged;
          if(handler != null) handler(this, new PropertyChangedEventArgs(property));
       }
       event INotifyPropertyChanged.PropertyChanged {
          add { propertyChanged += value; }
          remove { propertyChanged -= value;}
       }
       public string FullName { 
          get { 
               return String.Format("{0}, {1}", LastName, FirstName);
          } 
       }
       string firstName;
       string lastName; 
       public string FirstName {
         get { return firstName;}
         set {
            if(firstName != value){
               firstName = value;
               OnPropertyChanged("FirstName");
               //also trigger PropertyChanged for FullName
               OnPropertyChanged("FullName");
            }
         }
       }
       public string LastName {
         get { return lastName;}
         set {
            if(lastName != value){
               lastName = value;
               OnPropertyChanged("LastName");
               //also trigger PropertyChanged for FullName
               OnPropertyChanged("FullName");
            }
         }
       }
    } 
