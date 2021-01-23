        private FileInfo[] files;
        private DirectoryInfo directory;
        private void Form1_Load(object sender, EventArgs e)
        {
            directory = new DirectoryInfo(@"C:\Users\smelendez\downloads");
            files = directory.GetFiles("*.txt");
            foreach (FileInfo file in files)
            {
                listBox1.Items.Add(file.Name);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedFile = files[listBox1.SelectedIndex];
            
            richTextBox1.Text = "";
            richTextBox1.Text = File.ReadAllText(selectedFile.FullName);
        }
