    public partial class MainForm : Form
    {
        InfoForm forwardForm;
        public MainForm() // constructor
        {
            InitializeComponent();
            this.forwardForm = new InfoForm(this);
        }
        private void GoBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            forwardForm.StartPosition = FormStartPosition.CenterParent;
            forwardForm.ShowDialog(this);
        }
    }
    public partial class InfoForm : Form
    {
        MainForm previous;
        public InfoForm(MainForm prevForm) // constructor
        {
            InitializeComponent();
            this.previous = prevForm;
        }
        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            previous.Show();
        }
    }
