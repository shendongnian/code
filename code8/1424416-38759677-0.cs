    public void launchMovie(PictureBox[] pics, string[] vidFilePaths)
        {
            int i = 0;
            for (i = 0; i < p-1; i++)
            {
                pics[i].Tag = i;
                pics[i].Click += (sender, EventArgs) =>
                {
                    int k = Convert.ToInt32((sender as PictureBox).Tag);
                    Form2 f2 = new Form2("file:///" + vidFilePaths[k]);
                    this.Hide();
                    f2.Show();
                };
            }
        }
