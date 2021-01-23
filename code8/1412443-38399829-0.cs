    public class ViewModelOne{
    
    }
    
    public class ViewModelTwo{
    
    }
    
    
    public class MasterClass : Control{
    
        public void CheckViewModel(){
             if(this.DataContext is ViewModelOne){
    
             }
             else if(this.DataContext is ViewModelTwo){
    
             }
        }
    
    }
