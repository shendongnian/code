     Point MP;
     //private Control PB;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
             int picSizeX = Properties.Resources.police.Width / 3;
             int picSizeY = Properties.Resources.police.Height / 3;
            PictureBox pb = new PictureBox();
            pb.Location = new Point(100, 100);
            pb.Size = new Size(picSizeX, picSizeY);
            pb.Image = new Bitmap(Properties.Resources.police);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(pb);
            pb.Tag = "veh";
            //PB = pb;
            pb.MouseDown += Pb_MouseDown;
            pb.MouseMove += Pb_MouseMove;
            pb.MouseHover += Pb_MouseHover;
        }
        private void Pb_MouseHover(object sender, EventArgs e)
        {
            Control pbObj = sender as PictureBox; //sender refers to subject cotrol
            pbObj.MouseHover += PB_MouseHover;
        }
        private void PB_MouseHover(object sender, EventArgs e)
        {
        }
        private void Pb_MouseDown(object sender, MouseEventArgs e)
        {
            MP = e.Location;
        }
        private void Pb_MouseMove(object sender, MouseEventArgs e)
        {
            Control pbObj = sender as PictureBox;
            if (e.Button == MouseButtons.Left)
            {
                pbObj.Left = e.X + pbObj.Left - MP.X;
                pbObj.Top = e.Y + pbObj.Top - MP.Y;
            }
        }
