    private string userName;
    private string fileDirectory;
    
    public AddFileForm(Files _file) : this(_file.userName, _file.directory) {  }
    public AddFileForm(string user, string directory)
    {
        userName = user;
        fileDirectory = directory;
        InitializeComponent();
    }
    
    private void buttonAdd_Click(object sender, EventArgs e)
    {
        userName = listBoxUserList.SelectedItem.ToString();
        fileDirectory = listBoxItems.SelectedItem.ToString();
            try
            {
                Files file = new Files();
                file.userName = userName;
                file.directory = fileDirectory;
                DBConnection connection = new DBConnection();
                connection.AddFile(file);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed database connection!");
            }
        }
