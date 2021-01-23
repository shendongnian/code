    public class Modal : Form
    {
        public Modal {
            InitializeComponent();
        }
        private void Confirm_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
        private void Cancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }
    }
