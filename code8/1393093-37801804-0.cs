    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    namespace Project
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }
        Bitmap background;
        Graphics scG;
        Rectangle rectangleObj;
        Rectangle center;
        int clikno = 0;
        private Point clickCurrent = Point.Empty;
        private Point clickPrev = Point.Empty;
  
        private void Form1_Load(object sender, EventArgs e)
        {
            background = new Bitmap(this.Width, this.Height);//, this.Width,this.Height);
            rectangleObj = new Rectangle(10, 10, 100, 100);
            center = new Rectangle(10, 10, 3, 3);
            scG = Graphics.FromImage(background);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            clickCurrent = this.PointToClient(Cursor.Position);
            clickPrev = clickCurrent;
            if (clickPrev == Point.Empty) return;
            Refresh();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.DrawImage(Draw(), 0, 0);
        }
        public Bitmap Draw()
        {
            Graphics scG = Graphics.FromImage(background);
            Pen myPen = new Pen(System.Drawing.Color.Red, 3);
            scG.Clear(SystemColors.Control);
            scG.DrawEllipse(myPen, rectangleObj);
          //  scG.DrawRectangle(myPen, rectangleObj);
            scG.DrawEllipse(myPen, center);
            return background;
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            clikno = clikno + 1;
        }
       
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
           double oradius = Math.Sqrt((Math.Pow(clickPrev.X - e.X, 2)) + (Math.Pow(clickPrev.Y - e.Y, 2)));
         int radius = Convert.ToInt32(oradius);
            if (clikno == 1)
            {
               rectangleObj.Height = radius;
               rectangleObj.Width = radius;
                rectangleObj.X = clickPrev.X- rectangleObj.Height /2;// +radius; 
                rectangleObj.Y = clickPrev.Y - rectangleObj.Width / 2;// +radius; 
                center.X = clickPrev.X - center.Height / 2;// +radius; 
                center.Y = clickPrev.Y - center.Width / 2;// +radius; 
                Refresh();
            }
            if (clikno == 2)
                clikno = 0;
            Refresh();
        }
        string myString = 5.ToString();
    }
}
