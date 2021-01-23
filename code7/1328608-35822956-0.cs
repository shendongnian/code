    public partial class Form1 : Form
    {
        List<Bitmap> bitmaps = new List<Bitmap>();
        int pos = 0;
        public Form1()
        {
            InitializeComponent();
            AddBitmaps();
            if (bitmaps.Count > 0)
            {
                pboxSCREEN.Image = bitmaps[0];
            }
        }
        void AddBitmaps()
        {
            bitmaps.Add(new Bitmap(Path.Combine(Environment.CurrentDirectory, @"Resources\resident.gif")));
            bitmaps.Add(new Bitmap(Path.Combine(Environment.CurrentDirectory, @"Resources\start2.jpg")));
        }
        public void btnForward_Click(object sender, EventArgs e)
        {
            if (pos > 0 && pos <= bitmaps.Count)
            {
                pos--;
                pboxSCREEN.Visible = true;
                pboxSCREEN.Image = bitmaps[pos];
            }
        }
        public void btnBackward_Click(object sender, EventArgs e)
        {
            if (pos + 1 < bitmaps.Count)
            {
                pos++;
                pboxSCREEN.Visible = true;
                pboxSCREEN.Image = bitmaps[pos];
            }
        }
    }
