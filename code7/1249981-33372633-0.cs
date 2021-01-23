    private void Form1_Load(object sender, EventArgs e)
    {
        try // Get the tif file from C:\image\ folder
        {
            string path = @"C:\image\";
            String filename = Directory.EnumerateFiles(path, "*.png").FirstOrDefault();
            if (null != filename) {
              // Load picture 
              pictureBox1.Load(filename);
              // Show the file name
              lblFile.Text = filename;
            }
            else {
              //TODO: No *.png files are found
            } 
        }
        catch(IOException ex)
        {
            MessageBox.Show("No files or " + ex.Message);
        }
    }
