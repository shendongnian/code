    public void launchMovie(PictureBox[] pics, string[] vidFilePaths)
    {
        for (int i = 0; i < p - 1; i++)
        {
            pics[i].Tag = vidFilePaths[i];
            pics[i].Click += (sender, EventArgs) =>
            {
                int index = 
                selectedFilePath = "file:///" + pics[i].Tag.ToString();
                Form2 f2 = new Form2(selectedFilePath);
                this.Hide();
                f2.Show();
            };
        }
    }
