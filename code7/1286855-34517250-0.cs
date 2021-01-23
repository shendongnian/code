    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace LightUpWholeCurve
    {
    public partial class Form1 : Form
    {
        public List<GraphLine> SinArr = new List<GraphLine>();
        public List<GraphLine> Bowditch = new List<GraphLine>();
        public List<GraphLine> CircArr = new List<GraphLine>();
        
        public List<List<GraphLine>> MasterArr = new List<List<GraphLine>>();
        public List<GraphLine> MasterArrayOfGraphLines = new List<GraphLine>();
        GraphLine SelectedLine = null;
        MoveInfo Moving = null;
        public Form1()
        {
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(LineMover_Paint);
            this.MouseMove += new MouseEventHandler(LineMover_MouseMove);
            this.MouseDown += new MouseEventHandler(LineMover_MouseDown);
            this.MouseUp += new MouseEventHandler(LineMover_MouseUp);
            MakeSinArray();
            MakeBowditchArray();
            MakeCircleArray();
            //Create a lists of lists of each curve
            this.MasterArr.Add(SinArr);
            this.MasterArr.Add(Bowditch);
            this.MasterArr.Add(CircArr);
            foreach (var fullcurve in MasterArr)
            {
                foreach (var GL in fullcurve)
                {
                    MasterArrayOfGraphLines.Add(GL);
                }
            }
            //You must use initialize component or you'll get a small window
            //Also, keep in mind that if you cut and paste a whole file you
            //must change the namespace, or it won't recognize "InitializeComponent
            InitializeComponent();
        }
        void MakeBowditchArray()
        {
            int numberOfSeg = 100;
            double TwoPI = (float)(2 * Math.PI) / numberOfSeg;
            for (int t = 0; t <= numberOfSeg; t++)
                this.Bowditch.Add(new GraphLine(
                    500 + 25 * (float)Math.Sin(3 * TwoPI * t),
                    300 + 25 * (float)Math.Cos(5 * TwoPI * t),
                    500 + 25 * (float)Math.Sin(3 * TwoPI * (t + 1)),
                    300 + 25 * (float)Math.Cos(5 * TwoPI * (t + 1))));
        }
        void MakeSinArray()
        {
            int numberOfSeg = 100;
            double TwoPI = (float)(2 * Math.PI) / numberOfSeg;
            for (int t = 0; t <= numberOfSeg; t++)
                this.SinArr.Add(new GraphLine(
                    200 + 25 * (float)t / 20,
                    200 + 25 * (float)Math.Sin(3 * TwoPI * t),
                    200 + 25 * (float)(t + 1) / 20,
                    200 + 25 * (float)Math.Sin(3 * TwoPI * (t + 1))));
        }
        void MakeCircleArray()
        {
            int numberOfSeg = 50;
            double TwoPI = (float)(2 * Math.PI) / numberOfSeg;
            for (int t = 0; t <= numberOfSeg; t++)
                this.CircArr.Add(new GraphLine(
                    300 + 25 * (float)Math.Sin(TwoPI * t),
                    300 + 25 * (float)Math.Cos(TwoPI * t),
                    300 + 25 * (float)Math.Sin(TwoPI * (t + 1)),
                    300 + 25 * (float)Math.Cos(TwoPI * (t + 1))));
        }
        private void LineMover_MouseUp(object sender, MouseEventArgs e)
        {
            if (Moving != null)
            {
                this.Capture = false;  //Capture is part of Control.Capture
                Moving = null;
            }
            RefreshLineSelection(e.Location);
        }
        private void LineMover_MouseDown(object sender, MouseEventArgs e)
        {
            RefreshLineSelection(e.Location);
            if (this.SelectedLine != null && Moving == null)
            {
                this.Capture = true; //gets or sets a bool whether control has captured the mouse.
                Moving = new MoveInfo
                {
                    Line = this.SelectedLine,
                    StartLinePoint = SelectedLine.StartPoint,
                    EndLinePoint = SelectedLine.EndPoint,
                    StartMoveMousePoint = e.Location
                };
            }
            RefreshLineSelection(e.Location);
        }
        private void LineMover_MouseMove(object sender, MouseEventArgs e)
        {
            if (Moving != null)
            {
                Moving.Line.StartPoint = new PointF(Moving.StartLinePoint.X + e.X - Moving.StartMoveMousePoint.X, Moving.StartLinePoint.Y + e.Y - Moving.StartMoveMousePoint.Y);
                Moving.Line.EndPoint = new PointF(Moving.EndLinePoint.X + e.X - Moving.StartMoveMousePoint.X, Moving.EndLinePoint.Y + e.Y - Moving.StartMoveMousePoint.Y);
            }
            RefreshLineSelection(e.Location);
        }
        private void LineMover_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //Look at every GraphLine in SinArray and if it is the segment selected, 
            //then turn it to the color Red
            Color color1 = Color.Blue;
            Pen pen1 = new Pen(color1, 2);
            foreach (var line in SinArr)
            {
                if (line == SelectedLine)
                {
                    color1 = Color.Red;
                    pen1 = new Pen(color1, 2);
                    break;
                }
            }
            foreach (var line in SinArr)
            {
                e.Graphics.DrawLine(pen1, line.StartPoint, line.EndPoint);
            }
            //Go through entire array in Bowditch and check to see if any line was selected.
            //If it was, then set color to Red
            color1 = Color.Blue;
            pen1 = new Pen(color1, 2);
            foreach (var line in Bowditch)
            {
                if (line == SelectedLine)
                {
                    color1 = Color.Red;
                    pen1 = new Pen(color1, 2);
                    break;
                }   
            }
            foreach (var line in Bowditch)
            {
                e.Graphics.DrawLine(pen1, line.StartPoint, line.EndPoint);
            }
            
            
            
            
            
            color1 = Color.Blue;
            pen1 = new Pen(color1, 2);
            foreach (var line in CircArr)
            {
                if (line == SelectedLine)
                {
                    color1 = Color.Red;
                    pen1 = new Pen(color1, 2);
                    break;
                }
            }
            foreach (var line in CircArr)
            {
                e.Graphics.DrawLine(pen1, line.StartPoint, line.EndPoint);
            }
            
        }
        private void RefreshLineSelection(Point point)
        {
            
            var selectedLine = FindLineByPoint(MasterArrayOfGraphLines, point);
            if (selectedLine != this.SelectedLine)
            {
                this.SelectedLine = selectedLine;
                this.Invalidate();
            }
            if (Moving != null)
                this.Invalidate();
            this.Cursor =
                Moving != null ? Cursors.Hand :
                SelectedLine != null ? Cursors.SizeAll :
                  Cursors.Default;
        }
        static GraphLine FindLineByPoint(List<GraphLine> lines, Point p)
        {
            var size = 40;
            var buffer = new Bitmap(size * 2, size * 2);
            foreach (var line in lines)
            {
                //draw each line on small region around current point p and check pixel in point p 
                //does it really draw all the lines from this.Lines = new List<GraphLine>() ? [I wrote that]
                using (var g = Graphics.FromImage(buffer))
                {
                    g.Clear(Color.Black);  //Makes entire buffer black
                    g.DrawLine(new Pen(Color.Green, 3),  //makes a line through it green
                        line.StartPoint.X - p.X + size,
                        line.StartPoint.Y - p.Y + size,
                        line.EndPoint.X - p.X + size,
                        line.EndPoint.Y - p.Y + size);
                }
                if (buffer.GetPixel(size, size).ToArgb() != Color.Black.ToArgb())
                    return line;
            }
            return null;
        }
        public class MoveInfo
        {
            public GraphLine Line;
            public PointF StartLinePoint;
            public PointF EndLinePoint;
            public Point StartMoveMousePoint;
        }
        public class GraphLine
        {
            public GraphLine(float x1, float y1, float x2, float y2)
            {
                this.StartPoint = new PointF(x1, y1);
                this.EndPoint = new PointF(x2, y2);
            }
            public PointF StartPoint;
            public PointF EndPoint;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
    }
