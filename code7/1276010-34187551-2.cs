    private Image _Source = null;
    private int _TotalPages = 0;
    private int _CurrentPage = 0;
    
    private void Frm_TiffViewer_Load(object sender, EventArgs e)
    {
        lbl_WaitMessage.Visible = false;
    
        // These two options can be adjusted as needed and probably should be set in the form control properties directly:
        pictureBox1.Size = new Size(750, 1100);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
    }
    
    private void ShowProcessingImageLabel()
    {
        lbl_WaitMessage.Visible = true;
        Application.DoEvents();
    }
    
    private void DisplayPage(int PageNumber, RotateFlipType Change)
    {
        if (pictureBox1.Image != null && pictureBox1.Image != _Source)
        {
            // Release memory for old rotated image
            pictureBox1.Image.Dispose();
        }
    
        //  set the variable to null for easy GC cleanup
        pictureBox1.Image = null;
    
        _Source.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, PageNumber - 1);
    
        pictureBox1.Image = new Bitmap(_Source);
    
        pictureBox1.Image.RotateFlip(Change);
    
        pictureBox1.Refresh();
    }
            
    private void DisplayPage(int PageNumber)
    {
        ShowProcessingImageLabel();
    
        this.lblCurrPage.Text = PageNumber.ToString();
    
        // You could adjust the PictureBox size here for each frame  OR adjust the image to fit the picturebox nicely.
        if (Radio_90_Rotate.Checked == true)
        {
            DisplayPage(PageNumber, RotateFlipType.Rotate90FlipNone);
            lbl_WaitMessage.Visible = false;
            return;
        }
        else if (Radio_180_Rotate.Checked == true)
        {
            DisplayPage(PageNumber, RotateFlipType.Rotate180FlipNone);
            lbl_WaitMessage.Visible = false;
            return;
        }
    
        if (pictureBox1.Image != _Source)
        {
            if (pictureBox1.Image != null)
            {
                // Release memory for old copy and set the variable to null for easy GC cleanup
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
    
            pictureBox1.Image = _Source;
        }
    
        pictureBox1.Image.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, PageNumber-1);
                
        pictureBox1.Refresh();
    
        lbl_WaitMessage.Visible = false;
    }
    
    
    private void Open_Btn_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            // Before loading you should check the file type is an image
    
            this._Source = Image.FromFile(openFileDialog1.FileName);
    
            _TotalPages = _Source.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
            _CurrentPage = 1;
    
            lblCurrPage.Text = "1";
            lblFile.Text = openFileDialog1.FileName;
            this.lblNumPages.Text = _TotalPages.ToString();
    
            DisplayPage(_CurrentPage);
        }
    }
    
    private void NextPage_btn_Click(object sender, EventArgs e)
    {
        if (_CurrentPage < _TotalPages)
        {
            _CurrentPage++;
        }
    
        DisplayPage(_CurrentPage);
    }
    
    private void b_Previous_Click(object sender, EventArgs e)
    {
        if (_CurrentPage > 1)
        {
            _CurrentPage--;
        }
    
        DisplayPage(_CurrentPage);
    }
    
    private void Radio_90_Rotate_CheckedChanged(object sender, EventArgs e)
    {
        DisplayPage(_CurrentPage);
    }
    
    private void Radio_180_Rotate_CheckedChanged(object sender, EventArgs e)
    {
        DisplayPage(_CurrentPage);
    }
    
    private void Radio_0_Default_CheckedChanged(object sender, EventArgs e)
    {
        DisplayPage(_CurrentPage);
    }
