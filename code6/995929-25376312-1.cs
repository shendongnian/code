    public partial class Program: DevExpress.XtraBars.Ribbon.RibbonForm {
    UserControl Campus = null;
    
     public Program()
        {
            InitializeComponent();
             Campus  = new WindowsFormsApplication1.Campus();
        }
    
     private void Program_Load(object sender, EventArgs e) {
      // remove this object creation
     //var Campus = new WindowsFormsApplication1.Campus();
    
            pnlPanel.Panel2.Controls.Add(Campus);
       ... 
    }
    
     public void Reset() {
      // remove this object creation
     //  var Campus = new WindowsFormsApplication1.Campus();
    }
    
    
    private void chkDisplay_EditValueChanged(object sender, EventArgs e) {
    
     string displayInfo = "";
      // remove this object creation
     // var Campus = new WindowsFormsApplication1.Campus();
    }
    
    }
