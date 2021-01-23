    public partial class Form1 : Form
    {
        ...
        UserControl1 uc1;
        public Form1()
        {
            InitializeComponent();
            // creates new control and pass owner via constructor parameter
            uc1 = new UserControl1(this);
            Controls.Add(uc1);
            uc1.Visible = true;
            uc1.UserControl1Event += new EventHandler(Handleuc1);
        }
        ...
    }
    
    public partial class UserControl1 : UserControl
    {
        Form1 frm1;
        public UserControl1(Form1 owner)
        {
            // save user control owner passed from constructor parameter to local variable
            frm1 = owner;
        }
        ...
    }
