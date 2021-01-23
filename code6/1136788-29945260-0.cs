        // get the list of paths to the files from your directory into an array
        var fileList = Directory.GetFiles(@"C:\Images","*.jpg");
        
        // create a flowlayout panel
        FlowLayoutPanel p = new FlowLayoutPanel();
        
        foreach (string path in fileList) 
        {
           Image i = new Bitmap(path);
           PictureBox p = new PictureBox();
           p.Image = i;
           f.Controls.Add(p);
        }
    
    // add the panel to the form
    this.Controls.Add(p);
