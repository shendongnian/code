    private void coverButton_Click(object sender, EventArgs e)
    {
        var dialogResult = openFileDialog.ShowDialog(this);
    
        if (dialogResult == DialogResult.OK)
        {
            TagLib.File file = TagLib.File.Create(openFileDialog.FileName);
            var mStream = new MemoryStream();
            var firstPicture = file.Tag.Pictures.FirstOrDefault();
            if (firstPicture != null)
            {
                byte[] pData = firstPicture.Data.Data;
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                var bm = new Bitmap(mStream, false);
                mStream.Dispose();
                coverPictureBox.Image = bm;
            }
            else
            {
                // set "no cover" image
            }
        }
    }
