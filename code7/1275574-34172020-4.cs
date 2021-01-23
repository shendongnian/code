    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication
    {
        public partial class Form1 : Form
        {
            Line myLine;
            int x1 = 10;
            int x2 = 40;
            int y1 = 0;
            int y2 = 30;
            public Form1()
            {
                InitializeComponent();
                myLine = new Line() { Start = new Point(x1, y1), Stop = new Point(x2, y2), Epsilon = 10 };
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                pen.Dispose();
            }
    
            private void Form1_Click(object sender, EventArgs e)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                bool contain = myLine.contain(new Point(me.X,me.Y));
            }
        }
    
        public class Line
        {
            public Point Start { get; set; }
            public Point Stop { get; set; }
            public float Epsilon { get; set; }
            public bool contain(Point p)
            {
                // y = mx + c
                float m = (Stop.Y - Start.Y) / (Stop.X - Start.X);
                float c = Stop.Y - (m * Stop.X);
                return p.X >= Math.Min(Start.X, Stop.X)
                    && p.X <= Math.Max(Start.X, Stop.X)
                    && p.Y >= Math.Min(Start.Y, Stop.Y)
                    && p.Y <= Math.Max(Start.Y, Stop.Y)
                    && Math.Abs(Math.Abs(p.Y) - Math.Abs((m * p.X) + c)) < epsilon; //with relax rules
                    //&& (p.Y == (m*p.X)+c); // strict version
            }
        }
    
