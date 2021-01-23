    public class ComparableImageForm : Form
    {
        // This is the property we need to expose:
        public ComparableImage Image
        {
            get { return this.image; }
            set { SetImage(value); }
        }
        private ComparableImage image;
        private PictureBox pictureBox = new PictureBox()
        {
            Dock = DockStyle.Fill
        };
        public ComparableImageForm()
        {
            this.Controls.Add(pictureBox);
        }
        // For clarity, we are also setting a picture box image
        // from the ComparableImage when it is assigned:
        private void SetImage(ComparableImage image)
        {
            this.image = image;
            pictureBox.Image = image.Image;
        }
    }
