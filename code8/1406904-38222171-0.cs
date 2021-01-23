    public partial class Form1 : Form
    {
    
        SaveFileDialog saveDialog;
        public Form1()
        {
            InitializeComponent();
            // create instance of SaveFileDialog
            saveDialog = new SaveFileDialog();
            // registration of the event
            saveDialog.FileOk += SaveDialog_FileOk;
        }
    
        private void saveButton_Click(object sender, EventArgs e)
        {
            saveDialog.ShowDialog();
        }
    
        private void saveDialog_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveDialog.FileName;
            File.WriteAllText(name, inputTextBox.Text);
        }
    }
