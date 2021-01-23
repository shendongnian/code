    // Variable to hold the current page number
    private int intCurrPage = 0; 
    private int intTotalPages = 0;
    private void Open_Btn_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            lblFile.Text = openFileDialog1.FileName; 
            // Before loading you should check the file type is an image
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Size = new Size(pictureBox1.Image.Height, pictureBox1.Image.Width);
            intTotalPages = pictureBox1.Image.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
            lblNumPages.Text = intTotalPages.ToString();
        }
    }
    private void NextPage_btn_Click(object sender, EventArgs e)
    {
        if (intCurrPage < (intTotalPages-1))
        {
            //page increment (Go to next page)
            intCurrPage++; 
            // Directly increment the active frame within the image already in the PictureBox
            pictureBox1.Image.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, intCurrPage);
            // Adjust the size of the picturebox control to the size of the current page.
            // not sure if this is necessary, but including it due to prior example
            pictureBox1.Size = new Size(pictureBox1.Image.Height, pictureBox1.Image.Width);
            // Refresh the PictureBox so that it will show the currently active frame
            pictureBox1.Refresh();
            lblCurrPage.Text = intCurrPage.ToString();
        }
    }
