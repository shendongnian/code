    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.FileOk += OpenFileDialog1_FileOk;
        }
    
        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string path = ((OpenFileDialog)sender).FileName;
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    label1.Text = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "");
                }
            }
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            //show file dialog on form load
            openFileDialog1.ShowDialog();
        }
    }
