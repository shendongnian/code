    public class LayeredPictureBox : PictureBox
    {
        public LayeredPictureBox()
        {
            SetStyle(
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.UserPaint |
              ControlStyles.ResizeRedraw, true);
        }
         public List<Bitmap> blocks = new List<Bitmap>();
         public int x = 0, y = 0;
         protected override void OnPaint(PaintEventArgs e)
         {
             foreach (Bitmap block in blocks)
             {
                 e.Graphics.DrawImage(block, x, y);
             }
         }
     }
    private void Form1_Load(object sender, EventArgs e)
    {  
        RapidPictureBox pictureBox1 = new RapidPictureBox();
        pictureBox1.Dock = DockStyle.Fill;
        Controls.Add(pictureBox1);
        pictureBox1.blocks.Add(new Bitmap("3.png")); //first initial image
        pictureBox1.blocks.Add(new Bitmap("2.png")); //draw on the initial one.
    }
