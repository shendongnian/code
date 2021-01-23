    public partial class frmMain : Form
    {
        private PrivilegeCheck _check { get; set; }
        // Form constructor
	    public frmMain(PrivilegeCheck check)
	    {
            _check = check;
	        InitializeComponent();
	    }
   
        // ... Use _check in your form.
    }
