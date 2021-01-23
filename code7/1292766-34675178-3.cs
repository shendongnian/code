    class RotatedPictureBox : PictureBox
    {
        private Image image;
        public new  Image Image {
            get { return image; }  // ?? you may want to undo the rotation here ??
            set {
                  Bitmap bmp = value as Bitmap ;
                  // use the rotation you need!
                  if ( bmp != null )  bmp.RotateFlip(RotateFlipType.Rotate270FlipX);
                  image = bmp;
                  base.Image = Image;
                }
            }
        
        }
        public RotatedPictureBox ()
        {
        }
    }
