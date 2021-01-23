    public partial class Form1 : Form
    {
        BindingList<string> paths;
    
        public Form1()
        {
            InitializeComponent();
    
            paths = new BindingList<string>();
            paths.Add(@"Transfer");
            paths.Add(@"Transfer\Classified");
            paths.Add(@"Transfer\Keys");
            paths.Add(@"Transfer\Container");
            paths.Add(@"Transfer");
        }
    
        private void btnCreateFolders_Click(object sender, EventArgs e)
        {
            foreach (string dirCreate in paths)
            {
                try
                {
                    string strDirectoryName = String.Concat(txtFolderPath.Text, "\\", dirCreate);
    
                    if (!Directory.Exists(strDirectoryName))
                    {
                        Directory.CreateDirectory(strDirectoryName);
                    }
                    else
                    {
                        MessageBox.Show(String.Format("{0} already exists", dirCreate));
                    }
    
                }
                catch (UnauthorizedAccessException msg)
                {
                    MessageBox.Show(msg.Message);
                }
            }
        }
    }
