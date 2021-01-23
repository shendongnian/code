        public partial class Form1 : Form
        {
            Rectangle rec;
            Bitmap bmp;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                bmp = new Bitmap(@"YourImageUrlHere");
                rec = new Rectangle(0, 0, 100, 100);
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                if (bmp != null)
                    e.Graphics.DrawImage(bmp, rec);
            }
    
            //private void Form1_Click(object sender, EventArgs e)
            //{
            //    dont use this....
            //}
    
            private void Form1_MouseClick(object sender, MouseEventArgs e)
            {
                if(rec.Contains(e.Location))
                    MessageBox.Show("Test");
            }
        }
