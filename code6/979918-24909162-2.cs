     public class YourViewModel : ViewModelBase 
     {
          public ICommand SomeCommand { get; set; }
          public YourViewModel(......)
          {
              SomeCommand = new RelayCommand<SelectionChangedEventArgs>(YourCommandMethod);
          }
          private void YourCommandMethod(SelectionChangedEventArgs e)
          {
              // Do your magic here.... 
          }
     }
