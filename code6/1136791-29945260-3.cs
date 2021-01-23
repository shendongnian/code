        // get the list of paths to the files from your directory into an array
        var fileList = Directory.GetFiles(@"C:\Images","*.jpg");
        
        // create a flowlayout panel
        FlowLayoutPanel f = new FlowLayoutPanel();
        
        foreach (string path in fileList) 
        {
           Image i = new Bitmap(path);
           PictureBox p = new PictureBox();
           p.Image = i;
           p.Click += OnImageClick; // this will let you have the same event for all of the pictures
           f.Controls.Add(p);
        }
    
    // add the panel to the form
    this.Controls.Add(p);
    // this is what handles the clicks
    private void OnImageClick(object sender, EventArgs e)
            {
                // I will leave this for you to implement... the 'sender' is the picturebox that was clicked.
                // you can get it back to a PictureBox by casting, like (PictureBox)sender
                throw new NotImplementedException();
            }
