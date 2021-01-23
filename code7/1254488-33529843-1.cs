    private void Form1_Load(object sender, EventArgs e) //When form load you do this:
    { 
        try // Get the tif file from C:\image\ folder
        {
            string path = @"C:\image\";
            string[] filename = Directory.GetFiles(path, "*.tif"); //gets a specific image doc.
            FileInfo fi = new FileInfo(filename[0]);
            byte [] buff = new byte[fi.Length];
            using ( FileStream fs = File.OpenRead(fileToDisplay) )
            {
                fs.Read(buff, 0, (int)fi.Length);      
            }
            MemoryStream ms = new MemoryStream(buff);
            Bitmap img1 = new Bitmap(ms);
            opened = true; // the files was opened.
            pictureBox1.Image = img1;
   
            pictureBox1.Width = img1.Width;
            pictureBox1.Height = img1.Height;
            picWidth = pictureBox1.Width;
            picHeight = pictureBox1.Height;
            getRatio();  
        }
        catch (Exception ex)
        {
            MessageBox.Show("No files or " + ex.Message);
        }          
    }
