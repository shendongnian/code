    private async void Save_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtSignby.Text.ToString()) && MyIP.Strokes != null && MyIP.Strokes.Count > 0)
        {
            WriteableBitmap wbBitmap = new WriteableBitmap(MyIP, new TranslateTransform());
            EditableImage eiImage = new EditableImage(wbBitmap.PixelWidth, wbBitmap.PixelHeight);
            cmd = new CustomMessageBox()
            {
                Caption = "SAVING....",
                Message = "Please wait...."
            };
            cmd.Show();
            await Task.Delay(10);
            //some code
            //some code
            //some code
            //some code
            cmd.Dismiss();
        }
    }
