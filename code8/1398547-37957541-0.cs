    private void showImage(string path)
    {
       Image oldImage = pictureBox1.Image;
       Image imgtemp = Image.FromFile(path);
       pictureBox1.Image = imgtemp;
       if(oldImage != null)
           oldImage.Dispose();
    }
