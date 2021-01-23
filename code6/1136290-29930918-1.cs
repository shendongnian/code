    public partial class MainForm : Form
    {
       private int MainFormMember{ get; set; }
       private CustomUserControl customUserControl;
       
       public MainForm()
       {
            InitializeComponent();
            // Create and add the CustomUserControl manually and not from ToolBox
            customUserControl = new CustomUserControl(this);
            this.Controls.Add(customUserControl);
       }
       
       ...
       ...
    }
