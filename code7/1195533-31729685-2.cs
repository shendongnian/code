    <UserControl ... DataContext="{Binding GenericViewModel}">
       
    </UserControl>
    
    public class MyControl : UserControl{
    
          public MyControl(){
             this.DataContext = MasterViewModel();
          }
    }
    
    public class MasterViewModel {
          
         //This can be set and reset as much as you'd like
         public Object GenericViewModel {get; set;}
    
    }
