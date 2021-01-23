     private string _firstName;
     public string StudentFirstName
     {
         get { return _firstName; }
         set
         {
             if (value != _firstName) {
                 _firstName = value;
                 OnPropertyChanged("StudentFirstName");
             }
         }
     }
