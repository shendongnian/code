    namespace DatabaseToAPI
    {
        public partial class Add : Form
        {
            private string firstName;
            private string lastName;
            public Add()
            {
                InitializeComponent();
                this.Visible = false;
            }
            public string getFirstName()
            {
                return firstName;
            }
            public string getLastName()
            {
                return lastName;
            }
            private void addButton_Click(object sender, EventArgs e)
            {
                 if (firstNameBox.Text != "" && lastNameBox.Text != "")
                {
                    firstName = firstNameBox.Text;
                    lastName = lastNameBox.Text;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Please provide both first name and last name", "Sorry", MessageBoxButtons.OK);
                }
            }
            private void cancelButton_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
