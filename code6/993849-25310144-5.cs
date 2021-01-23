    public class YourViewModel: YourViewModelBaseClass {
       public ICommand YourCommand{ get; set; }
       public ViewModelOrCodeBehind() {
          InitStuff();
       }
       void  InitStuff(){
          YourCommand = new RelayCommand<MouseButtonEventArgs>(YourMethod);
       }
       void YourMethod(MouseButtonEventArgs e)
       {
           // Do your magic here
       }
    }
