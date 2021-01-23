    public class ShellViewModel : Conductor<IScreen>, IShell
    { 
       //INavigationViewModel is a "service interface" to the actual implimentation
       private INavigationViewModel _navmodel
       public class ShellViewModel(INavigationViewModel navmodel){
           
           _navmodel = navmodel;   
        
       }
    } 
    //can be done as long as NavigationViewModel is in the container of your choosing
