    private int int_Current_Page = 0;
    private void btnNextImage_Click_1(object sender, EventArgs e)
    {
        Image image2;
        try
        {
            if (int_Current_Page == Convert.ToInt32(lblNumPages.Text)) // if you have reached the last page it ends here
                                                                  // the "-1" should be there for normalizing the number of pages
            { int_Current_Page = Convert.ToInt32(lblNumPages.Text); }
            else
            {                   
                int_Current_Page++; //page increment
                Refresh_Image();
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void btnPrevImage_Click_1(object sender, EventArgs e)
    {
        if (int_Current_Page == 0) // it stops here if you reached the bottom, the first page of the tiff
        { int_Current_Page = 0; }
        else
        {
            int_Current_Page--; // if its not the first page, then go to the previous page
            Refresh_Image(); // refresh the image on the selected page
        }
    }
    private void openButton_Click_1(object sender, EventArgs e)
    {
        Refresh_Image(); //Opens the large image document
    }
    FileStream _stream; 
    Image _myImg; // setting the selected tiff
    private void Refresh_Image()
    {
        // Image myImg; // setting the selected tiff - Now a member variable
        Image myBmp; // a new occurance of Image for viewing
        if (_myImg == null)
        {
            _stream = new FileStream(@"C:\my_Image_document", FileMode.Open, FileAccess.Read)
            _myImg = Image.FromStream(_Stream);
        }
        int intPages = _myImg.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page); // getting the number of pages of this tiff
        intPages--; // the first page is 0 so we must correct the number of pages to -1
        lblNumPages.Text = Convert.ToString(intPages); // showing the number of pages
        lblCurrPage.Text = Convert.ToString(int_Current_Page); // showing the number of page on which we're on
        _myImg.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, int_Current_Page); // going to the selected page
        myBmp = new Bitmap(_myImg, pictureBox1.Width, pictureBox1.Height);
        pictureBox1.Image = myBmp; // showing the page in the pictureBox1  
    }
    protected override void Dispose(bool disposing)
    {
        if (_stream != null) _stream.Dispose();
        base.Dispose(disposing);
    }
