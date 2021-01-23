    void ChangeImage(Bitmap b) {
      Image oldImage = PictureBox.Image;
      PictureBox.Image = b;
      if (oldImage != null) {
        oldImage.Dispose();
      }
    }
