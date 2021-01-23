    public Form1()
    {
        InitializeComponent();
        Task.Run(async () => await loadComboEmail());
    }
    
    private async Task loadComboEmail()
    {
        string path = Directory.GetCurrentDirectory();
        string build = (path + "\\" + "email.txt");
        string[] lines = System.IO.File.ReadAllLines(build);
        comboEmail.Items.AddRange(lines);
        comboEmail.SelectedIndex=0;
    }
