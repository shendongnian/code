    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        public Bitmap Draw(int width, int height)
        {
            Bitmap myBitmap = new Bitmap(width, height);
    
            using (var graphics = Graphics.FromImage(myBitmap))
            {
                graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(2,2,20,20));
            }
    
            return myBitmap;
        }
    
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Draw(PB1.Width, PB1.Height);
        }
    
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PB1.Image = e.Result as Bitmap;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    
    }
