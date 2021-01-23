    public class SingleAppInstance : WindowsFormsApplicationBase
    {
      public SingleAppInstance()
      {
          this.IsSingleInstance = true;    
          this.StartupNextInstance += StartupNextInstance;
      }
    
      void StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
      {
          // here's the code that will be executed when an instance
          // is opened.
          // the command line arguments will be in e.CommandLine
      }
    
      protected override void OnCreateMainForm()
      {
        // This will be your main form: i.e, the one that is in
        // Application.Run() in your original Program.cs
        this.MainForm = new Form1();
      }
    }
