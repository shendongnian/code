    class RotatedPictureBox : PictureBox
    {
        private Image image;
        public new  Image Image {
            get { return image; }  // ?? you may want to undo the rotation here ??
            set {
                Bitmap bmp = value as Bitmap ;
                if (bmp != null)
                {                  // use the rotation you need!
                    bmp.RotateFlip(RotateFlipType.Rotate270FlipX);
                    image = bmp;
                    base.Image = Image;
                }
            }
        
        }
        public RotatedPictureBox ()
        {
        }
    }
