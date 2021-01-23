    MainWindow.cs
    public class MainWindow :Form
     {
        DesignTools designer;
        public event EventHandler event1 = delegate { }; 
        public MainWindow  mainWindowSM{get;set;}
        public PEMainWindow()
        {
          InitializeComponent();
            ...
        }
        InitializeComponent()
        {
          .....          
          this.mainWindowSM = new MainWindow();
        }
        private void BtnDesignTools_Click(object sender, EventArgs e)
        {
          if (designer == null)
		  {
              designer = new DesignTools();
	      }
          
          designer.BtnNudgeDown_Click(this, e);
        }
     }
    public class DesignTools : Form 
    { 
     public DesignTools()
     {
		
     }
     private void BtnNudgeDown_Click(object sender, EventArgs e)
     {
        ...
     }
    }
