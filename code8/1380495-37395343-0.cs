    private void SetViewerImage()
    {
        Bitmap image = new Bitmap(/* Some stream*/);
        pictureBox1.Invoke(new Action(() =>
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;  // This might help? Only add if it does.
                }
                pictureBox1.Image = image;
            }));
    }
