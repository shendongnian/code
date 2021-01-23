    public partial class MyForm : Form
    {
       ...
       System.Timers.Timer timer; 
      
       public void Timerss()
       {
          timer = new System.Timers.Timer(5000); 
       }
    
       ...
    }
