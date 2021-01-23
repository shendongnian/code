    public partial class MainForm : Form
    {
        DummyControl1 dummy1;
        DummyControl2 dummy2;
        
        public MainForm()
        {
            InitializeComponent();
            
      
            dummy1 = new DummyControl1();
            dummy2 = new DummyControl2();
            pnlCentre.Controls.Add(dummy1);
            pnlCentre.Dock = DockStyle.Fill;
        }
        // switches between screens
        public void switchscreen()
        {
            pnlCentre.Controls.Remove(dummy1);
            pnlCentre.Controls.Add(dummy2);
            pnlCentre.Dock = DockStyle.Fill;
           
        }
    }
    public partial class DummyControl1 : UserControl
    {
        // can be filled from the designer
    }
    public partial class DummyControl2 : UserControl
    {
        // can be filled from the designer
    }
