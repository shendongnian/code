    protected void uploadBtnClick(object sender, EventArgs e)
    {
        if (this.fileUpload.HasFile)
        {
            // file gets uploaded to szSaveToPath
            lblStatus.Text = Validation.CheckWellFormed(szSaveToPath);
            //do things
        }
    }
