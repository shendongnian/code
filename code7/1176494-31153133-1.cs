    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WinFormDrawGraphics
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                SetStyle(ControlStyles.ResizeRedraw, true);
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                // initialization
                Graphics g = e.Graphics;
    
                // Create pen.
                Pen blackPen = new Pen(Color.Black, 3);
    
                // Create points that define line.
                Point point1 = new Point(100, 100);
                Point point2 = new Point(500, 100);
    
                // Draw line to screen.
                e.Graphics.DrawLine(blackPen, point1, point2);
    
                // add any other graphics drawing...
            }
        }
    }
