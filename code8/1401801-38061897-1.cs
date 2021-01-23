    public Form1()
    {
        InitializeComponent();
        if(!File.Exists(tabTitles)) // check if the file exists, (you had a check on mainFolder)
        {
            Directory.CreateDirectory(mainFolder);
            Directory.CreateDirectory(tabTitlesFolder);
            var file = File.Create(tabTitles); // this is what you are creating so also what you should be checking for above in the if
            file.Close();
        }
    } 
