    public class App : Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    {
        public App()
        {
            // Make this a single-instance application
            this.IsSingleInstance = true; 
            this.EnableVisualStyles = true;
        }
        protected override void OnCreateMainForm()
        {
            // Create an instance of the main form 
            // and set it in the application; 
            // but don't try to run() it.
            this.MainForm = new Form1();
        }
    }
