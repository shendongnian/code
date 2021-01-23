    public void launchMovie(PictureBox[] pics, string[] vidFilePaths)
    {
        for (int i = 0; i < p - 1; i++)
        {
            int currentIndex = i;
            pics[i].Click += (sender, EventArgs) =>
            {
                selectedFilePath = "file:///" + vidFilePaths[currentIndex];
                Form2 f2 = new Form2(selectedFilePath);
                this.Hide();
                f2.Show();
            };
        }
    }
