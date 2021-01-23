        public Form1()
        {
            InitializeComponent();
            pnlHang.Paint += PnlHangPaint;
            pnlHang.Resize += (sender, args) => pnlHang.Invalidate();
        }
        private void pnlHang_Paint(object sender, PaintEventArgs paintEventArgs)
        {
            drawHangPost(paintEventArgs.Graphics);
        }
        void drawHangPost(Graphics g)
        {
            //Use panel size percentages to draw the post
            double dWidth = pnlHang.Width;
            double dHeight = pnlHang.Height;
            int x1 = (int)Math.Round(0.8 * dWidth);
            int x2 = (int)Math.Round(0.45 * dWidth);
            int y1 = (int)Math.Round(dHeight);
            int y2 = (int)Math.Round(0.23 * dHeight);
            int xInit = x1;
            int xFinal = x1 - x2;
            int yInit = y1;
            int yMiddle = 10;
            int yFinal = y2;
            //Paint Post
            using (Pen p = new Pen(Color.Brown, 10))
            {
                g.DrawLine(p, new Point(xInit, yInit), new Point(xInit, yMiddle));
                g.DrawLine(p, new Point(xInit, yMiddle), new Point(xFinal, yMiddle));
                g.DrawLine(p, new Point(xFinal, yMiddle), new Point(xFinal, yFinal));
            }
        }
