    private void genButton_Click(object sender, EventArgs e)
    {
        Task.Run(() => GenerateNewBitmap());
    }
    
    private void GenerateNewBitmap()
    {
        //Changing size also changes collection behavior
        //If this is a small bitmap then collection happens
        var size = picBox.Size;
        Bitmap bmp = new Bitmap(size.Width, size.Height);
        //Generate some pixels and Invoke it onto UI if you wish
        //Call again for an infinite loop
        Task.Run(() => GenerateNewBitmap());
    }
