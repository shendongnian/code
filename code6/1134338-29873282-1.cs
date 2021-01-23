    namespace DataTransferBetweenForms
    {
        public partial class DestinationForm : Form
        {
            public string LabelText
            {
                get { return label1.Text; }
                set { label1.Text = value; }
            }
            public DestinationForm()
            {
                InitializeComponent();
            }
        }
    }
