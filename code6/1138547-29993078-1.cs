    public partial class Form1 : Form
    {
        private Bitmap bm;
        private bool bDrawn = false;
        
        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(pB.ClientRectangle.Width, pB.ClientRectangle.Height);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            if (bDrawn)
            {
                Graphics gF = pB.CreateGraphics();
                gF.Clear(Color.Silver);
                gF.DrawRectangle(Pens.Black, 5, 5, 100, 60);
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            //Graphics gF = pB.CreateGraphics();
            //gF.Clear(Color.Silver);
            ///gF.DrawRectangle(Pens.Black, 5, 5, 100, 60);
            bDrawn = true;
            this.Invalidate();
        }
