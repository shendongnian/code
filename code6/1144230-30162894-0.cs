    MainWindow.cs
    public class MainWindow :Form
     {
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
          this.BtnNudgeDown.Click += new System.EventHandler(this.event1);
          this.mainWindowSM = new MainWindow();
        }
        private void BtnDesignTools_Click(object sender, EventArgs e)
        {
          DesignTools designer = new DesignTools(this);
        }
     }
    public class DesignTools : Form 
    { 
     public DesignTools(MainWindow window)
     {
     window.event1 += this.BtnNudgeDown_Click;
     }
     private void BtnNudgeDown_Click(object sender, EventArgs e)
     {
        ...
     }
    }
