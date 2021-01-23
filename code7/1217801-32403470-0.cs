        private Bitmap _img;
        public void LoadImage(string file) {
            // Get the image from the file.
            pictureBox1.Image = Bitmap.FromFile(file);
            // Convert it to a bitmap and store it for later use.
            _img = (Bitmap)pictureBox1.Image;
            // Code for stretching the picturebox here.
            // ...
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            var color = _img.GetPixel(e.X, e.Y);
        }
