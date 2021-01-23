    private void Form1_Load(object sender, EventArgs e)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string workingDirectoryPlus1 = (currentDirectory + 1);
            string checkFile = (".\\check.txt");
            bool newFolder = (File.Exists(checkFile));
            if (newFolder)
            {
                newFolder = true;
            }
            else
            {
                newFolder = false;
                File.Create(".\\check.txt");
            }
        }
