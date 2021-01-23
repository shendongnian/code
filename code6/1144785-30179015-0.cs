    private string sourcePath;
    private string destinationPath;
    public Form1()
    {
        destinationPath = @"c:\users\name\desktop\"; // f.e.
        InitializeComponent();
    }
    //Browse Button
    private void button1_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog dlg = new OpenFileDialog())
        {
            dlg.Title = "Open Image";
            dlg.Filter = "bmp files (*.bmp)|*.bmp"; // you can filter whatever format you want
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sourcePath = dlg.FileName;
            }
        }
    }
    //Set Background Button
    private void button2_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(sourcePath) && File.Exists(sourcePath))
        {
            destinationPath += Path.GetFileName(sourcePath);
            File.Move(sourcePath, destinationPath);
        }
    }
