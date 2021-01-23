    public partial class PatientRegister : Form
    {
        private CentralStation centralStation;
        public PatientRegister(CentralStation cs)
        {
            InitializeComponent();
            //here you get the reference of the centralStation 
            this.centralStation = cs;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                MessageBox.Show("You did not enter anything, please enter the patients name.");
            }
            else
            {
                // this.centralStation is the one you have hidden
                this.centralStation.centralModule1.lblPatientName = txtPatientName.Text;
            }
        }
    }
