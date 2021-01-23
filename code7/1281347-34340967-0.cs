    private void Form1_Load(object sender, EventArgs e)
    {
        int a=75,b=27;
        DirectoryInfo d = new DirectoryInfo(@"C:\images\52");
        FileInfo[] files = d.GetFiles("*.png");
        foreach(FileInfo f in files)
        {
        PictureBox p = new PictureBox();
        p.Location = new Point(a + 137, b);
       p.Image = Image.FromFile(Path.Combine(f.DirectoryName, f.Name));
       p.Size = new System.Drawing.Size(137, 171);
       p.SizeMode = PictureBoxSizeMode.StretchImage;
       this.Controls.Add(p);
       a += 75;
       p.BringToFront();
      }
     }
