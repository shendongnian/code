    string[] x = System.IO.Directory.GetFiles(@"C:\Users\bassp\Dropbox\VS Projects\WindowsFormsApplication1\WindowsFormsApplication1\Resources\", "*.jpg");
    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
    List<images> imagelist=new List<images>();
    foreach (string f in x)
    {
        images img= new images();
        img.fullpath = Path.GetFullPath(f);
        img.filename = Path.GetFileNameWithoutExtension(f);
        imagelist.Add(img);
    }
    listBox1.DisplayMember = "filename";
    listBox1.ValueMember = "fullpath";
    listBox1.DataSource = imagelist;
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        pictureBox1.ImageLocation = ((images)listBox1.SelectedItem).fullpath;
    }
