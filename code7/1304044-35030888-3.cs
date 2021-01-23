    public partial class MainWindow : Form
    {
        private Dialog m_Dialog;
        public MainWindow()
        {
            InitializeComponent();
            m_Dialog = new Dialog();
            this.Click += closeDialog;
        }
        private void closeDialog(object sender, EventArgs e)
        {
            m_Dialog.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            m_Dialog.Show();
        }
    }
