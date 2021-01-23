    public class SomeViewModel: INotifyPropertyChanged
    {
         // INotifyPropertyChanged members
         public event PropertyChangedEventHandler PropertyChanged;
         public void OnPropertyChanged(PropertyChangedEventArgs e)
         {
            if (PropertyChanged != null)
                   PropertyChanged(this, e);
         }
         // Input property
         private string _input;
         public string InputGrid1
         {
           get
           {
                return _input;
           }
           set
           {
               if (value < 0 || value > 100 )
               {
                  IsEditable = true;
               }
               _input= value;
               OnPropertyChanged(new PropertyChangedEventArgs("InputGrid1"));
           }
         }
         // ... The same for InputGrid2
         // bool property
         private bool _isEditable;
         public bool IsEditable
         {
           get
           {
                return _isEditable;
           }
           set
           {
               _input= _isEditable;
               OnPropertyChanged(new PropertyChangedEventArgs("IsEditable"));
           }
         }
    } 
