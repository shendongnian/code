    public partial class Form1 : Form
    {
        private Timer tmr;
        private int PupilRadius = 20;
        private int EyeBallRadius = 50;
        private int DistanceBetweenEyes = 20;
        public Form1()
        {
            InitializeComponent();
            this.panel1.Paint += panel1_Paint;
            tmr = new Timer();
            tmr.Interval = 100;
            tmr.Tick += tmr_Tick;
            tmr.Start();
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
        void panel1_Paint(object sender, PaintEventArgs e)
        {
            Point center = new Point(panel1.ClientSize.Width / 2, panel1.ClientSize.Height / 2);
            Point LeftEyeCenter = new Point(center.X - EyeBallRadius - (DistanceBetweenEyes / 2), center.Y);
            Point RightEyeCenter = new Point(center.X + EyeBallRadius + (DistanceBetweenEyes / 2), center.Y);
            
            Rectangle rc = new Rectangle(LeftEyeCenter, new Size(1, 1));
            rc.Inflate(EyeBallRadius, EyeBallRadius);
            e.Graphics.DrawEllipse(Pens.Black, rc);
            rc = new Rectangle(RightEyeCenter, new Size(1, 1));
            rc.Inflate(EyeBallRadius, EyeBallRadius);
            e.Graphics.DrawEllipse(Pens.Black, rc);
            Point curPos = panel1.PointToClient(Cursor.Position);
            Double DistanceFromLeftEyeToCursor = getDistance(LeftEyeCenter.X, LeftEyeCenter.Y, curPos.X, curPos.Y);
            Double DistanceFromRightEyeToCursor = getDistance(RightEyeCenter.X, RightEyeCenter.Y, curPos.X, curPos.Y);
            double angleLeft = getAngleInDegrees(LeftEyeCenter.X, LeftEyeCenter.Y, curPos.X, curPos.Y);
            double angleRight = getAngleInDegrees(RightEyeCenter.X, RightEyeCenter.Y, curPos.X, curPos.Y);
            rc = new Rectangle(new Point(Math.Min((int)DistanceFromLeftEyeToCursor, EyeBallRadius - PupilRadius), 0), new Size(1, 1));
            rc.Inflate(PupilRadius, PupilRadius);
            e.Graphics.TranslateTransform(LeftEyeCenter.X, LeftEyeCenter.Y);
            e.Graphics.RotateTransform((float)angleLeft - 90);
            e.Graphics.FillEllipse(Brushes.Blue, rc);
            rc = new Rectangle(new Point(Math.Min((int)DistanceFromRightEyeToCursor, EyeBallRadius - PupilRadius), 0), new Size(1, 1));
            rc.Inflate(PupilRadius, PupilRadius);
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(RightEyeCenter.X, RightEyeCenter.Y);
            e.Graphics.RotateTransform((float)angleRight - 90);
            e.Graphics.FillEllipse(Brushes.Blue, rc);
        }
        private Double getDistance(int Ax, int Ay, int Bx, int By)
        {
            return Math.Sqrt(Math.Pow((Double)Ax - Bx, 2) + Math.Pow((Double)Ay - By, 2));
        }
        private Double getAngleInDegrees(int cx, int cy, int X, int Y)
        {
            // draw a line from the center of the circle
            // to the where the cursor is...
            // If the line points:
            // up = 0 degrees
            // right = 90 degrees
            // down = 180 degrees
            // left = 270 degrees
            Double angle;
            int dy = Y - cy;
            int dx = X - cx;
            if (dx == 0 ) // Straight up and down | avoid divide by zero error!
            {
                if (dy <=0)
                {
                    angle = 0;
                }
                else
                {
                    angle = 180;
                }
            }
            else
            {
                angle = Math.Atan((Double)dy / (Double)dx);
                angle = angle * ((Double)180 / Math.PI);
                if (X > cx)
                {
                    angle = 90 + angle;
                }
                else
                {
                    angle = 270 + angle;
                }
            }
            return angle;
        }
    }
