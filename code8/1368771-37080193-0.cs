    #region Methods for Transforms on Bunkers
        public void SetRotationTransformation(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.RotateTransform(chuteAngle);
        }
        public void InvertRotationTransformation(System.Windows.Forms.PaintEventArgs e, int width, int X, int height, int Y)
        {
            e.Graphics.TranslateTransform(width / 2 + X, height / 2 + Y);
            e.Graphics.RotateTransform(-chuteAngle);
            e.Graphics.TranslateTransform(-1 * (width / 2 + X), -1 * (height / 2 + Y));
        }
        public void SetTranslateTransformation(System.Windows.Forms.PaintEventArgs e, int width, int X, int height, int Y)
        {
            e.Graphics.TranslateTransform(width / 2 + X, height / 2 + Y);
        }
        public void InvertTranslateTransformation(System.Windows.Forms.PaintEventArgs e, int width, int X, int height, int Y)
        {
            e.Graphics.TranslateTransform(-1 * (width / 2 + X), -1 * (height / 2 + Y));
        }
        #endregion
