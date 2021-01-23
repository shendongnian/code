    List<PictureBox> picturebox = List<PictureBox>;
    var y = 10;
    foreach (var file in recentpics)
    {
       var pb = new PictureBox();                
       pb.Location = new Point(picturebox.Count * 120 + 20, y);
       pb.Size = new Size(100, 120);                
       pb.Image = Image.FromFile(file.FullName);
       this.Controls.Add(pb);
       picturebox.Add(pb);
    }
