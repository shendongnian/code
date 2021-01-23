    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private Point clickCurrent = Point.Empty;
            private Point clickPrev = Point.Empty;
            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                clickPrev = clickCurrent;
                clickCurrent = this.PointToClient(Cursor.Position);
                if (clickPrev == Point.Empty) return;    
                Graphics g;
                double oradius = Math.Sqrt((Math.Pow(clickPrev.X - clickCurrent.X, 2)) + (Math.Pow(clickPrev.Y - clickCurrent.Y, 2)));
                int radius = Convert.ToInt32(oradius);
                g = this.CreateGraphics();
                Rectangle rectangle = new Rectangle();
                PaintEventArgs arg = new PaintEventArgs(g, rectangle);
                DrawCircle(arg, clickPrev.X, clickPrev.Y, radius * 2, radius * 2);
            }
            private void DrawCircle(PaintEventArgs e, int x, int y, int width, int height)
            {
                System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Red, 3);
                e.Graphics.DrawEllipse(pen, x - width / 2, y - height / 2, width, height);
            }
        }
    }
