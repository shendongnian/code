    public class Operate
    {
    public async void operations()
    {
     statusBox.Text = "processing";
    
     await Task.Run(()=>{
     //do work here
     });
     
     status.Text = "finished";
    }
    }   
