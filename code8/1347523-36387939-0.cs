    public Default()
    {
        InitializeComponent();
        LoadComboBox();
    }
    void LoadComboBox()
    {
        ModuleSelectorComboBox.Items.Clear();
        string[] files = Directory.GetFiles(@"C:\Modules");
        foreach (string file in files)
            ModuleSelectorComboBox.Items.Add(Path.GetFileNameWithoutExtension(file));
    }
            
