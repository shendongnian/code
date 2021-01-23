     //this method will rotate an image any degree
       public static Bitmap RotateImage(Bitmap image, float angle)
        {
            //create a new empty bitmap to hold rotated image
            double radius = Math.Sqrt(Math.Pow(image.Width, 2) + Math.Pow(image.Height, 2));
            Bitmap returnBitmap = new Bitmap((int)radius, (int)radius);
            //make a graphics object from the empty bitmap
            using (Graphics graphic = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                graphic.TranslateTransform((float)radius / 2, (float)radius / 2);
                //rotate
                graphic.RotateTransform(angle);
                //move image back
                graphic.TranslateTransform(-(float)image.Width / 2, -(float)image.Height / 2);
                //draw passed in image onto graphics object
                graphic.DrawImage(image, new Point(0, 0));
            }
            return returnBitmap;
        }
