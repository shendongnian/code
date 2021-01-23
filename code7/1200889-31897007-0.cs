    public partial class Form1 : Form
    {
        private const int segmentLength = 10;
        private GraphicsPath gpPrimes = null;
        public Form1()
        {
            InitializeComponent();
            nudLessThanMax.Minimum = 15;
            nudLessThanMax.Maximum = 500000;
            nudLessThanMax.Value = nudLessThanMax.Minimum;
            pnlPrimes.Paint += PnlPrimes_Paint;
            pnlPrimes.SizeChanged += PnlPrimes_SizeChanged;
        }
        private void PnlPrimes_SizeChanged(object sender, EventArgs e)
        {
            pnlPrimes.Invalidate();
        }
        private void PnlPrimes_Paint(object sender, PaintEventArgs e)
        {
            if (gpPrimes != null)
            {
                RectangleF rectF = gpPrimes.GetBounds();
                float max = Math.Max(rectF.Width + (2 * segmentLength), rectF.Height + (2 * segmentLength));
                e.Graphics.TranslateTransform(pnlPrimes.Width / 2, pnlPrimes.Height / 2);
                e.Graphics.ScaleTransform((float)pnlPrimes.Width / max, (float)pnlPrimes.Height / max);
                e.Graphics.TranslateTransform(-(rectF.Left + rectF.Width / 2), -(rectF.Top + rectF.Height / 2));
                e.Graphics.DrawPath(Pens.Black, gpPrimes);
            }
        }
        private void btnGraphPrimes_Click(object sender, EventArgs e)
        {
            btnGraphPrimes.Enabled = false;
            backgroundWorker1.RunWorkerAsync((int)this.nudLessThanMax.Value);
        }
        private List<int> PrimesLessThan(int num) // SLaks: http://stackoverflow.com/a/1510186/2330053
        {
            return Enumerable.Range(0, (int)Math.Floor(2.52 * Math.Sqrt(num) / Math.Log(num))).Aggregate(
                Enumerable.Range(2, num - 1).ToList(),
                (result, index) =>
                {
                    var bp = result[index]; var sqr = bp * bp;
                    result.RemoveAll(i => i >= sqr && i % bp == 0);
                    return result;
                }
            );
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int diff;
            int num = (int)e.Argument;
            Point pt = new Point(0, 0);
            Point pt2 = pt;
            GraphicsPath gp = new GraphicsPath();
            List<int> primes = PrimesLessThan(num);
            for(int i = 1; i < primes.Count; i++)
            {
                diff = primes[i] - primes[i - 1];
                switch(i % 4)
                {
                    case 1: // up
                        pt2 = new Point(pt.X, pt.Y - (segmentLength * diff));
                        break;
                    case 2: // left
                        pt2 = new Point(pt.X - (segmentLength * diff), pt.Y);
                        break;
                    case 3: // down
                        pt2 = new Point(pt.X, pt.Y + (segmentLength * diff));
                        break;
                    case 0: // right
                        pt2 = new Point(pt.X + (segmentLength * diff), pt.Y);
                        break;
                }
                gp.AddLine(pt, pt2);
                pt = pt2;
            }
            gpPrimes = gp;
            e.Result = primes;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbPrimes.DataSource = (List<int>)e.Result;
            pnlPrimes.Invalidate();
            btnGraphPrimes.Enabled = true;
        }
    }
