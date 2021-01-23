    public partial class Form1 : Form
    {
        Pen pen = Pens.Black;
        //private int averageDepth;
        //private int answer;
        public Form1 ()
        {
            InitializeComponent();
            deepEndTrackbar.Minimum = 120;
            deepEndTrackbar.Maximum = 180;
            deepEndLabel.Text = Convert.ToString(deepEndTrackbar.Value);
            shallowEndTrackbar.Minimum = 120;
            shallowEndTrackbar.Maximum = 180;
            shallowEndLabel.Text = Convert.ToString(shallowEndTrackbar.Value);
            lengthTrackbar.Minimum = 120;
            lengthTrackbar.Maximum = 180;
            lengthLabel.Text = Convert.ToString(lengthTrackbar.Value);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // reset the trackbar values:
            shallowEndTrackbar.Value = 120;
            deepEndTrackbar.Value = 120;
            lengthTrackbar.Value = 120;
            pictureBox1.Invalidate();
        }
        private void deepEndTrackbar_Scroll(object sender, EventArgs e)
        {
            deepEndLabel.Text = Convert.ToString(deepEndTrackbar.Value);
            pictureBox1.Invalidate();
        }
        private void shallowEndTrackbar_Scroll(object sender, EventArgs e)
        {
            shallowEndLabel.Text = Convert.ToString(shallowEndTrackbar.Value);
            pictureBox1.Invalidate();
        }
        private void lengthTrackbar_Scroll(object sender, EventArgs e)
        {
            lengthLabel.Text = Convert.ToString(lengthTrackbar.Value);
            pictureBox1.Invalidate();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics paper = e.Graphics;
            // reset the paper
            paper.Clear(Color.White);
            // draw the "D front lines:
            paper.DrawLine(pen, 40, 150, 200, 150);
            paper.DrawLine(pen, 200, 150, 200, 100 + shallowEndTrackbar.Value);
            paper.DrawLine(pen, 40, 150, 40, 100 + deepEndTrackbar.Value);
            paper.DrawLine(pen, 200, 100 + shallowEndTrackbar.Value, 40, 
                                     100 + deepEndTrackbar.Value);
            // perspective 2:3
            int lx = lengthTrackbar.Value / 2;
            int ly = lengthTrackbar.Value / 3;
            // draw the outer 3D lines:
            paper.DrawLine(pen, 40, 150, 40 + lx, 150 - ly);
            paper.DrawLine(pen, 200, 150, 200 + lx, 150 - ly);
            paper.DrawLine(pen, 200, 100 + shallowEndTrackbar.Value, 
                                200 + lx, 100 - ly + shallowEndTrackbar.Value);
            paper.DrawLine(pen, 40 + lx, 150 - ly, 40 + lx + 200 - 40, 150 - ly);
            paper.DrawLine(pen, 200 + lx, 150 - ly, 
                                200 + lx,  100 -ly + shallowEndTrackbar.Value);
        }
    }
