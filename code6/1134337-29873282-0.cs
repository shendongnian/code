    namespace DataTransferBetweenForms
    {
        public partial class SourceForm : Form
        {
            public SourceForm()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                var destinationForm = new DestinationForm();
                destinationForm.LabelText = textBox1.Text;
                destinationForm.Show();
            }
        }
    }
