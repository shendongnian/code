    namespace WindowsFormsApplication_Test
    {
        public partial class Form1 : Form
        {
            private Bitmap bm;
            
            public Form1()
            {
                InitializeComponent();
                bm = new Bitmap(pB.ClientRectangle.Width, pB.ClientRectangle.Height);
            }
    
            private void btn_Click(object sender, EventArgs e)
            {
                Graphics gF = pB.CreateGraphics();
                gF.Clear(Color.Silver);
                gF.DrawRectangle(Pens.Black, 5, 5, 100, 60);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Graphics gF = Graphics.FromImage(bm);
                gF.Clear(Color.Silver);
                gF.DrawRectangle(Pens.Black, 5, 5, 100, 60);
                pB.Image = bm;
            }
        
        }
    }
