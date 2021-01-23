    var files = System.IO.Directory.GetFiles(@"d:\pic", "*.jpg");
    foreach (var file in files)
    {
        using (var s = new System.IO.FileStream(file, System.IO.FileMode.Open))
        {
            var p = new PictureBox();
            p.Image = Image.FromStream(s);
            this.flowLayoutPanel1.Controls.Add(p);
        }
        System.IO.File.Delete(file);
    }
