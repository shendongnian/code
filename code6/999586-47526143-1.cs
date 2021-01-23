    private System.Windows.Forms.PictureBox picContent;
    this.picContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picContent_MouseDown);
    
    private void picContent_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.XButton1)
            MessageBox.Show("Back");
        if (e.Button == MouseButtons.XButton2)
            MessageBox.Show("Forward");
    }
