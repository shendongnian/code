    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LimeGreen);
            System.Drawing.Graphics formGraphics = e.Graphics; //this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, 200, 300));
        }
    }
