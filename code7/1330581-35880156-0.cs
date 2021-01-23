    public partial class frmLogin : Form
        {
           public bool LoggedIn
            {
                get { return loggedIn; }
            }
    
            public frmLogin()
            {
              
                InitializeComponent();
    
    
            }
    }
    
    // Now, in your forms, you can do.
    frmLogin frm = new frmLogin ();
    
    frm.ShowDialog();
    
    var value = frm.LoggedIn;
