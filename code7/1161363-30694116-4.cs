    public Form1()
    {
        InitializeComponent();
        loadComboEmail();
    }
    
    private async Task loadComboEmail()
    {
        string path = Directory.GetCurrentDirectory();
        string build = (path + "\\" + "email.txt");
        string[] lines = await Task.Run(() => File.ReadAllLines(build));
        comboEmail.Items.AddRange(lines);
        comboEmail.SelectedIndex=0;
    }
