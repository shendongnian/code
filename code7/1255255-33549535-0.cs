    private System.Windows.Forms.PictureBox[] imgVictim = new PictureBox[3]; //array for victim images
    public void victimsRun()
    {
        victimTimer.Enabled = true; //starts the timer
        string fileName = "";
        PictureBox[] victim = new PictureBox[3];
        for (int i = 0; i < imgVictim.Length; i++) // 0 - 2
        {
            try
            {
                fileName = "victim" + i.ToString() + ".png";
                if (System.IO.File.Exists(fileName))
                {
                    imgVictim[i] = new PictureBox();
                    imgVictim[i].Image = Image.FromFile("victim" + i.ToString() + ".png");
                }
                else
                {
                    // file does not exist or needs a path in front of it
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("NULL EXECEPTION!");
            }
        }
    }
