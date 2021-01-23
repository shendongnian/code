    public partial class SampleForm : Form
    {
        private List<ImageBox> imageBoxes = new List<ImageBox>();
        public SampleForm()
        {
            InitializeComponent();
            // pictureBox1.Load("C:\\sample.png");
            // Panel1 initialized as NonFlickeringPanel in code behind
            LoadImages();
            panel1.Invalidate();
        }
        private void LoadImages()
        {
            if (imageBoxes.Count > 0)
                imageBoxes.Clear();
            const int boxWidth = 25;
            const int boxHeight = 20;
            var img = pictureBox1.Image;
            int widthThird = (int)((double)img.Width / boxWidth + 0.5);
            int heightThird = (int)((double)img.Height / boxHeight + 0.5);
            for (int i = 0; i < boxHeight; i++)
            {
                for (int j = 0; j < boxWidth; j++)
                {
                    var bitmap = new Bitmap(widthThird, heightThird);
                    var rect = new Rectangle(j * widthThird, i * heightThird, widthThird, heightThird);
                    Graphics g = Graphics.FromImage(bitmap);
                    g.DrawImage(img, new Rectangle(0, 0, bitmap.Width, bitmap.Height), rect, GraphicsUnit.Pixel);
                    g.Dispose();
                    imageBoxes.Add(new ImageBox() { Image = bitmap, Rectangle = rect });
                }
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            var p = e.Location;
            foreach (var imgBox in imageBoxes)
            {
                if (imgBox.Rectangle.Contains(p))
                    imgBox.Selected = true; // do whatever you want with the selected image using imgBox.Image
                else
                    imgBox.Selected = false;
            }
            panel1.Invalidate();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (imageBoxes == null || imageBoxes.Count == 0)
                return;
            foreach (var imgBox in imageBoxes)
            {
                var bitmap = imgBox.Image;
                var rect = imgBox.Rectangle;
                e.Graphics.DrawImage(bitmap, rect, new Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);
                if (imgBox.Selected)
                    e.Graphics.DrawRectangle(new Pen(Color.Red, 2), rect);
            }
        }
    }
    public class ImageBox
    {
        public Bitmap Image { get; set; }
        public Rectangle Rectangle { get; set; }
        public bool Selected { get; set; }
    }
    public class NonFlickeringPanel : System.Windows.Forms.Panel
    {
        public NonFlickeringPanel()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        }
    }
