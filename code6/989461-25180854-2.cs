    public partial class frmProfile : Form
    {
        public frmProfile(Profile pf)
        {
            InitializeComponent();
            txtFirstName.Text = pf.FirstName;
            .....
        }
        .....
    }
