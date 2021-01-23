    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private  void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            folderBrowserDlg.ShowNewFolderButton = true;
            DialogResult dlgResult = folderBrowserDlg.ShowDialog();
            if (dlgResult.Equals(DialogResult.OK))
            {
                textBox1.Text = folderBrowserDlg.SelectedPath;
                Environment.SpecialFolder rootFolder = folderBrowserDlg.RootFolder;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                //notification to user
                return;
            }
            //var t = this.Controls["textBox1"] as TextBox;
            string[] extensions = { ".txt", ".aspx", ".css", ".cs" };
            string[] dizin = Directory.GetFiles(textBox1.Text, "*.*")
                .Where(f => extensions.Contains(new FileInfo(f).Extension.ToLower())).ToArray();
                listBox1.Items.AddRange(dizin);
            //string[] p = dizin;
            //listBox1.Items.Add(p);
        }
    }
