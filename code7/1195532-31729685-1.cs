    public class MyControl : UserControl{    
 
       public MyControl(Object viewModel){    
          this.DataContext = viewModel;
       }
     }
