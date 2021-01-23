    public class ViewModelOrCodeBehind : Something {
       public ICommand YourCommand{ get; set; }
       public ViewModelOrCodeBehind() {
          InitStuff();
       }
       void  InitStuff(){
          YourCommand = new RelayCommand<RoutedEventArgs>(YourMethod);
       }
       void YourMethod(RoutedEventArgs e)
       {
           // Do your magic here
       }
    }
