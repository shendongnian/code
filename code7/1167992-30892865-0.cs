    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!this.isClosingViaOkButton)
            {
                // ...do your rollback here.
                MessageBox.Show("Rolling back");
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            // ...do your committing here.
            this.isClosingViaOkButton = true;
            this.Close();
        }
        private bool isClosingViaOkButton;
    }
