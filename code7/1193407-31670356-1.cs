    public partial class form1 : Form
    {
       System.Windows.Forms.Timer tmrDelay;
        
       void SomeMethodWithDelay()
       {
           // code before delay here
           tmrDelay.Enabled = true;
           tmrDelay.Tick += Timer_Tick;
       }
    
       private void Timer_Tick(object sender, EventArgs e)
       {
           Thread.Sleep(5000);
             
           // your code here
           // disables timer to stop it
           tmrDelay.Enabled = false;
       }
    }
