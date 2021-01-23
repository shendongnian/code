    public class MyPageViewModel : ViewModelBase
    {  
         public async MyPageViewModel CreateAsync()
         {
             var model = new MyPageViewModel();
    
             SelectedText = await SomeTask();
             return model;
         }        
    
         private MyPageViewModel ()
         {
             _selectedText = "Welcome";   //Default text
         }
    
         private Task<string> SomeTask()
         {            
             return Task.Run(async () =>
             {
                 await Task.Delay(3000); //Dummy task. It will return the status of Task.
                 return "Thanks";         //Update Text       
             });         
          }
    }
